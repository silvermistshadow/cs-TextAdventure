using System;
using System.Collections.Generic;
using System.Numerics;

namespace TextAdventure.Game
{
    public delegate void gameAction();

    public class Game
    {

        public Dictionary<Vector3, Room> placegrid;
        public static Dictionary<String, Vector3> cardinals = new Dictionary<string, Vector3>(){
            { "north", new Vector3 (0, 1, 0) },
            { "south", new Vector3 (0, -1, 0) },
            { "west", new Vector3 (-1, 0, 0) },
            { "east", new Vector3 (1, 0, 0) },
            { "up", new Vector3 (0, 0, 1) },
            { "down", new Vector3 (0, 0, -1) },
            { "northwest", new Vector3 (-1, 1, 0) },
            { "northeast", new Vector3 (1, 1, 0) },
            { "southwest", new Vector3 (-1, -1, 0) },
            { "southeast", new Vector3 (1, -1, 0) }
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

                Console.WriteLine("What are you using?");
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