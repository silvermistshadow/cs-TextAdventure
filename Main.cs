using System;
using System.Collections.Generic;
using TextAdventure.Game;

namespace TextAdventure
{
    class Program
    {
        public static void Main()
        {
            string opening = @"In this game, you play as a doctor directing a tiny machine
            through a patient's body, in order to treat their illness.";

            Console.WriteLine($@"{opening} 
            type 'Start' to begin");
            string input = Console.ReadLine();

            if (input == "Start" || input == "start")
            {
                Init.start();

            }
            
        }
    }
}