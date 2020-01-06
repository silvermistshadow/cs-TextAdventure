using System;
using System.Collections.Generic;
using System.Numerics;

namespace TextAdventure.Game
{
    public delegate void gameAction();

    public class Game
    {
        public void TakeItem(Item taken)
        {
            if (taken.pos == user.position && taken.canBeTaken)
            {
                taken.inInventory = true;
                user.inventory.Add(taken);
            }
        }


        public Dictionary<Vector3, Room> placegrid;
        public static Dictionary<String, Vector3> cardinals = new Dictionary<string, Vector3>(){
            { "proximal", new Vector3 (0, 1, 0) },
            { "distal", new Vector3 (0, -1, 0) },
            { "ventral", new Vector3 (-1, 0, 0) },
            { "dorsal", new Vector3 (1, 0, 0) },
            { "cranial", new Vector3 (0, 0, 1) },
            { "caudal", new Vector3 (0, 0, -1) },
        };
        public Dictionary<String, Vector3> directions = cardinals;
        public string Difficulty { get; set; }
        
        public Player user;
        public Game()
        {
            user = new Player();
            Difficulty = "Normal";
            placegrid = new Dictionary<Vector3, Room>();
            user.position = new Vector3(0, 0, 0);
        }

        public Room readRoom(Vector3 position)
        {
            return placegrid[position];
        }
        public Item itemSearch(string term)
        {
            Item founditem = new Item();
            foreach(Item found in readRoom(user.position).items)
            {
                if (term == found.name || term == found.shorthand)
                {
                    founditem = found;
                }
                else
                {
                    break;
                }

            }
            foreach(Item found in user.inventory)
            {
                if (term == found.name || term == found.shorthand)
                {
                    founditem = found;
                }
            }
            return founditem;
        }
        public void addRoom(Room tobeadded, Vector3 Position)
        {
            placegrid.Add(Position, tobeadded);
        }
        public void dirGo(string direction, Room curroom)
        {
            if (directions.ContainsKey(direction))
            {
                if (curroom.exits.ContainsKey(direction))
                {
                    if (curroom.exits[direction] == false)
                    {
                        user.position += directions[direction];
                    }
                    else
                    {
                        Console.WriteLine(curroom.blockreasons[direction]);
                    }
                }
            }
            else
            {
                Console.WriteLine("What?");
            }
        }
        public void Look()
        {
            Console.WriteLine(readRoom(user.position).description);
            foreach (Item thing in readRoom(user.position).items)
            {
                Console.WriteLine($"I see a {thing.name} here.");
            }
            foreach (string exit in readRoom(user.position).exits.Keys)
            {
                Console.WriteLine($"I see an exit to the {exit}. It leads to the {readRoom(user.position + directions[exit]).Name}.");
            }
        }
        public void Look(Item lookedat)
        {
            switch (lookedat)
            {
                case null:
                    Console.WriteLine("What should I look at?");
                    break;
                default:
                    if (lookedat.pos == user.position || lookedat.inInventory == true)
                    {
                        Console.WriteLine(lookedat.name);
                        Console.WriteLine(lookedat.description);
                    }
                    else
                    {
                        Console.WriteLine($"I see no {lookedat} here.");
                    }

                    break;
            }
        }
        void Move(string moveExit)
        {
            user.position = user.position + directions[moveExit];
        }

    }
        public class Room
    {
        public string Name;
        public string description;
        public Dictionary<string, bool> exits;
        public Dictionary<string, string> blockreasons;
        public List<Item> items;
        public Room(string name, string desc)
        {
            description = desc;
            Name = name;
            items = new List<Item>();
            exits = new Dictionary<string, bool>
            { };
            blockreasons = new Dictionary<string, string>
            { };
        }
        public Room()
        {

        }
    }
    public class Item
    {

        public List<gameAction> actions;
        public string description;
        public Vector3 pos;
        public bool inInventory;
        public bool canBeTaken;
        public string shorthand;
        public string name;

        public Item(string Name, string Description, Vector3 initpos, bool canbetaken)
        {
            canBeTaken = canbetaken;
            name = Name;
            description = Description;
            Vector3 pos = initpos;
            shorthand = name.Split(' ').ToString();
            actions = new List<gameAction>();
            inInventory = false;
        }
        public Item()
        {

        }

        public void UseItem()
        {
            if (actions.Count > 0)
            {

                foreach (gameAction action in actions)
                {
                    action();
                }
            }
            if (actions.Count == 0)
            {

                Console.WriteLine("What should I use?");
            }

        }
    }
        public class Player
    {
        public Vector3 position;
        public List<Item> inventory;
        public Player()
        {
            position = new Vector3(0, 0, 0);
            inventory = new List<Item>();
        }


    }
    
}