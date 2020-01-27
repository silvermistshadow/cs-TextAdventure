using System;
using System.Collections.Generic;

using System.Numerics;

namespace TextAdventure
{
    public class Init
    {   public static Game newGame = new Game();
        public static Room spleen = new Room("Spleen", "This is the spleen. Not actually useless.", new Vector3(-1,0,0));
        public static Room pancreas = new Room("Pancreas", "This is the pancreas.", new Vector3(0,-1,0));
        public static Room leftLung = new Room("Left Lung", "This is the left lung.", new Vector3(0,1,1));
        public static Room rightLung = new Room("Right Lung", "This is the right lung.", new Vector3(0,-1,1));
        public static Room heart = new Room("Heart", "This is the heart, more or less.", new Vector3(0,0,1));
        public static Room aorta = new Room("Aorta", "This is the aorta.", new Vector3(-1,1,0));
        public static Room inferiorVenaCava = new Room("Inferior Vena Cava", "This is one of the venae cavae.", new Vector3(-2,0,0));
        public static Room smallIntestine = new Room("Small Intestine", "This is the small intestine", new Vector3(0,0,-1));
        public static Room liver = new Room("Liver", "This is the liver.", new Vector3(0,1,0));
        public static Room stomach = new Room("Stomach", "This looks like the stomach. It's my entry point to the rest of the body.", new Vector3(0));
        public static Dictionary<string, Vector3> start()
        {
            newGame.addRoom("stomach",stomach);
            newGame.addRoom("liver", liver);
            newGame.addRoom("small intestine", smallIntestine);
            newGame.addRoom("aorta", aorta);
            newGame.addRoom("inferior vena cava", inferiorVenaCava);
            newGame.addRoom("heart", heart);
            newGame.addRoom("left lung", leftLung);
            newGame.addRoom("right lung", rightLung);
            newGame.addRoom("spleen", spleen);
            newGame.addRoom("pancreas", pancreas);
            Dictionary<string, Vector3> stringRooms = new Dictionary<string, Vector3>
            {
                {"Stomach", new Vector3(0)},
                {"Liver", new Vector3(0,1,0)},
                {"Small Intestine", new Vector3(0,0,-1)},
                {"Aorta", new Vector3(-2,0,0)},
                {"Inferior Vena Cava", new Vector3(-1,1,0)},
                {"Heart", new Vector3(0,0,1)},
                {"Left Lung", new Vector3(0,-1,1)},
                {"Right Lung", new Vector3(0,1,1)},
                {"Spleen", new Vector3(0,-1,0)},
                {"Pancreas", new Vector3(-1,0,0)}
            };
            setGoalRoom(rooms: newGame.RoomList);
            return stringRooms;
        }

        public static void setGoalRoom(Dictionary<string, Room> rooms)
        {
            Room[] roomArray = new Room[rooms.Count];
            rooms.Values.CopyTo(roomArray, 0);
            roomArray[new Random().Next(1, roomArray.Length)].isGoalRoom = true;
        }

        public static void setRoomExits(Room toSet, Dictionary<string, bool> exitsToAdd)
        {
            toSet.exits = exitsToAdd;
        }

        public static void setBlockReasons(Room toSet, Dictionary<string, string> reasonsToAdd)
        {
            toSet.blockreasons = reasonsToAdd;
        }

        public static void exitAdder()
        {
            Dictionary<string, bool> stomachExits = new Dictionary<string, bool> 
            {
                {"left", false},
                {"right", false},
                {"ventral", true},
                {"dorsal", true},
                {"cranial", true},
                {"caudal", true}
            };
            setRoomExits(stomach, stomachExits);
        }

    }
}