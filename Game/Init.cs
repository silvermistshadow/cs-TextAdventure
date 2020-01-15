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
            newGame.addRoom(stomach, new Vector3(0));
            Room liver = new Room("Liver", "This is the liver.");
            newGame.addRoom(liver, new Vector3(0,1,0));
            Room smallIntestine = new Room("Small Intestine", "This is the small intestine");
            newGame.addRoom(smallIntestine, new Vector3(0,0,-1));
            Room aorta = new Room("Aorta", "This is the aorta.");
            Room inferiorVenaCava = new Room("Inferior Vena Cava", "This is one of the venae cavae.");
            newGame.addRoom(aorta, new Vector3(-1,0,0));
            newGame.addRoom(inferiorVenaCava, new Vector3(-1,1,0));
            Room heart = new Room("Heart", "This is the heart, more or less.");
            newGame.addRoom(heart, new Vector3(0,0,1));
            Room leftLung = new Room("Left Lung", "This is the left lung.");
            Room rightLung = new Room("Right Lung", "This is the right lung.");
            newGame.addRoom(leftLung, new Vector3(0,-1,1));
            newGame.addRoom(rightLung, new Vector3(0,1,1));
        }
    }
}