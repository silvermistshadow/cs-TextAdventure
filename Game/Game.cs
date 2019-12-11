using System;
using System.Collections.Generic;

namespace TextAdventure.Game
{
    public class Game
    {
        public string PlayerName { get; set;}
        public string Difficulty { get; set; }
        public int Score { get => _score; set => _score = value; }

        private static List<string> _inventory;
        private int _score;
        
        public Game(string name)
        {
            PlayerName = name;
            Difficulty = "Normal";
            Score = 0;
        }

        public static void AddItem(string item)
        {
            _inventory.Add(item);
        }
    }
}