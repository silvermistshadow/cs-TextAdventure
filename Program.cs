using System;
using System.Collections.Generic;
using System.Numerics;

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
                var stringRooms = Init.start();
                Vector3 startRoom = stringRooms["Stomach"];
                Console.WriteLine(@"Startup finished. This game is still in development; please read the readme for game commands.");
                while(true)
                {
                    string gameInput = Console.ReadLine();
                    if(gameInput.ToLower() == "quit")
                    {
                        break;
                    }
                    if (Init.newGame.directions.ContainsKey(gameInput.ToLower()))
                    {
                        Init.newGame.dirGo(gameInput, Init.newGame.RoomList[Init.newGame.user.curroom]);
                        Init.newGame.Look();
                        if(Init.newGame.RoomList[Init.newGame.user.curroom].isGoalRoom)
                        {
                            Console.WriteLine("You found the goal. If I were writing this game for real, there'd actually be something you'd need to do here, but there isn't. You just win.");
                            break;
                        }
                    }
                    if(gameInput.ToLower() == "look")
                    {
                        Init.newGame.Look();
                    }
                }
                Environment.Exit(0);

            }
            
        }
    }
}