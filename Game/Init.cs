using System;
using System.Collections.Generic;
using TextAdventure.Game;
using System.Numerics;

namespace TextAdventure
{
    public class Init
    {
        public static void start()
        {
            var newGame = new Game.Game();
            Room stomach = new Room("Stomach", "This looks like the stomach. It's my entry point to the rest of the body.");
            Vector3 stomachPos =  new Vector3(0);
            newGame.addRoom(stomach, stomachPos);
        }
    }
}