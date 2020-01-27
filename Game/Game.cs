using System;
using System.Collections.Generic;
using System.Numerics;

namespace TextAdventure
{
    public delegate void gameAction();

    public class Game
    {
        public Dictionary<String, Vector3> directions = cardinals;   
        public Player user;
        public Dictionary<string, Room> RoomList;
        public Game()
        {
            user = new Player();
            RoomList = new Dictionary<string, Room>();
            user.position = new Vector3(0, 0, 0);
        }
        public void TakeItem(Item taken)
        {
            if (taken.pos == user.position && taken.canBeTaken)
            {
                taken.inInventory = true;
                user.inventory.Add(taken);
            }
        }


        public static Dictionary<String, Vector3> cardinals = new Dictionary<string, Vector3>(){
            { "right", new Vector3 (0, 1, 0) },
            { "left", new Vector3 (0, -1, 0) },
            { "ventral", new Vector3 (1, 0, 0) },
            { "dorsal", new Vector3 (-1, 0, 0) },
            { "cranial", new Vector3 (0, 0, 1) },
            { "caudal", new Vector3 (0, 0, -1) },
        };


        public Room readRoom(string roomName)
        {
            return RoomList[roomName];
        }
        public Item itemSearch(string term)
        {
            Item founditem = new Item();
            foreach(Item found in readRoom(user.curroom).items)
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
        public void addRoom(string roomName, Room room)
        {
            RoomList.Add(roomName, room);
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
                        foreach(KeyValuePair<string, Room> roomName in RoomList)
                        {
                            if(roomName.Value.Position == user.position)
                            {
                                user.curroom = roomName.Key;
                                break;
                            }
                        }
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
            Console.WriteLine(readRoom(user.curroom).description);
            foreach (Item thing in readRoom(user.curroom).items)
            {
                Console.WriteLine($"I see a {thing.name} here.");
            }
            foreach (string exit in readRoom(user.curroom).exits.Keys)
            {
                Console.WriteLine($"I see an exit to the {exit}. It leads to the {readRoom(user.curroom + directions[exit]).Name}.");
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
        public bool isGoalRoom;
        public Vector3 Position;
        public Room(string name, string desc, Vector3 position)
        {
            description = desc;
            Name = name;
            items = new List<Item>();
            exits = new Dictionary<string, bool>();
            blockreasons = new Dictionary<string, string>();
            isGoalRoom = false;
            Position = position;
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
        public string curroom = "stomach";
        public Player()
        {
            position = new Vector3(0, 0, 0);
            inventory = new List<Item>();
        }


    }
    
}