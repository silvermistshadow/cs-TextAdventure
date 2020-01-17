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
                Console.WriteLine("Starting up. This could take a bit.");
                Init.start();
                var currRoom = Init.newGame.placegrid[stomach];
                Console.WriteLine(@"Startup finished. This game is still in development; please read the readme for game commands.");
                /*while(true)
                {
                    string gameInput = Console.ReadLine();
                    if (Init.newGame.directions.ContainsKey(gameInput.ToLower()))
                    {

                    }
                }*/
            }
            
        }
    }
}