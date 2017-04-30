using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Hotel Z" };
        public static List<string> FooterText = new List<string>() { "" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "You have woken up in your hotel room to the sounds of screeming " +
            "'The hotel is infested in ZOMBIES!' You quickly realize that " +
            "staying on the top floor was a terrible idea. Now you must escape. " +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your quest begins now.\n" +
            " \n" +
            "\tBut first lets find out a bit about you.\n" +
            " \n" +
            "\tPress any key to begin.\n";

            return messageBoxText;
        }

        /// <summary>
        /// text about starting location
        /// </summary>
        /// <returns></returns>
        public static string CurrentLocationInfo()
        {
            string messageBoxText =
                    "The 8th floor of the hotel. It is going to be a tough " +
                    "ask to make it all the way to the street. Most of the rooms are inaccessible " +
                    "due to a collapsed roof.\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Now lets find out a little background on our Hero.\n" +
                " \n" +
                "You will be prompted for the information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetHeroName()
        {
            string messageBoxText =
                "Enter your name Hero.\n" +
                " \n" +
                "Use the name you want us to call you during your escape attempt.";

            return messageBoxText;
        }

        public static string InitializeMissionGetHeroAge(Hero gameHero)
        {
            string messageBoxText =
                $"OK then, we will call you {gameHero.Name}.\n" +
                " \n" +
                "Enter your age below.\n" +
                " \n";

            return messageBoxText;
        }

        public static string InitializeMissionGetHeroRace(Hero gameHero)
        {
            string messageBoxText =
                $"{gameHero.Name}, it will be important for us to know what your background is.\n" +
                " \n" +
                "Enter your class below.\n" +
                " \n" +
                "Please use the choices listed below." +
                " \n";

            string raceList = null;

            foreach (Character.ClassType race in Enum.GetValues(typeof(Character.ClassType)))
            {
                if (race != Character.ClassType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeMissionEchoHeroInfo(Hero gameHero)
        {
            string messageBoxText =
                $"Very good then {gameHero.Name}.\n" +
                " \n" +
                "Ok now that we know more about you, lets see how long you survive." +
                " \n" +
                $"\tHero Name: {gameHero.Name}\n" +
                $"\tHero Age: {gameHero.Age}\n" +
                $"\tHero Class: {gameHero.Class}\n" +
                " \n" +
                "Press any key to begin your escape.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Hero gameTraveler, RoomLocation currentLocation)
        {
            string messageBoxText =
                $"\tTraveler Name: {gameTraveler.Name}\n" +
                $"\tTraveler Age: {gameTraveler.Age}\n" +
                $"\tTraveler Race: {gameTraveler.Class}\n" +
                " \n" +
                $"\tCurrent Location: {currentLocation.CommonName}\n" +
                " \n";

            return messageBoxText;
        }

        public static string CurrentLocationInfo(RoomLocation roomLocation)
        {
            string messageBoxText =
                $"Current Location: {roomLocation.CommonName}\n" +
                " \n" +
               roomLocation.Description;

            return messageBoxText;
        }

        public static string LookAround(RoomLocation roomLocation)
        {
            string messageBoxText =
                $"Current Location: {roomLocation.CommonName}\n" +
                " \n" +
                roomLocation.Description;

            return messageBoxText;
        }

        /// <summary>
        /// list all locations other than the current location
        /// </summary>
        /// <param name="gamehero">game traveler object</param>
        /// <param name="roomLocations">list of all space time locations</param>
        /// <returns></returns>
        public static string Travel(Hero gamehero, List<RoomLocation> roomLocations)
        {
            string messageBoxText =
                $"{gamehero.Name}, Aion Base will need to know the name of the new location.\n" +
                " \n" +
                "Enter the ID number of your desired location from the table below.\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "-------".PadRight(10) + "\n";

            //
            // display all locations except the current location
            //
            string roomLocationList = null;
            foreach (RoomLocation roomLocation in roomLocations)
            {
                if (roomLocation.RoomLocationID != gamehero.RoomLocationID)
                {
                    roomLocationList +=
                        $"{roomLocation.RoomLocationID}".PadRight(10) +
                        $"{roomLocation.CommonName}".PadRight(30) +
                        $"{roomLocation.Accessible}".PadRight(10) +
                        Environment.NewLine;
                }
            }

            messageBoxText += roomLocationList;

            return messageBoxText;
        }

        public static string VisitedLocations(IEnumerable<RoomLocation> roomLocations)
        {
            string messageBoxText =
                "Room Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string roomLocationList = null;
            foreach (RoomLocation roomLocation in roomLocations)
            {
                roomLocationList +=
                    $"{roomLocation.RoomLocationID}".PadRight(10) +
                    $"{roomLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += roomLocationList;

            return messageBoxText;
        }

        public static string ListAllRoomLocations(IEnumerable<RoomLocation> roomLocations)
        {
            string messageBoxText =
                "Room Locations\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string roomLocationList = null;
            foreach (RoomLocation roomLocation in roomLocations)
            {
                roomLocationList +=
                    $"{roomLocation.RoomLocationID}".PadRight(10) +
                    $"{roomLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += roomLocationList;

            return messageBoxText;
        }

        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Room Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.RoomLocationID}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string ListAllNpcObjects(IEnumerable<Npc> npcObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "NPC Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Room Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all npc objects in rows
            //
            string npcObjectRows = null;
            foreach (Npc npcObject in npcObjects)
            {
                npcObjectRows +=
                    $"{npcObject.Id}".PadRight(10) +
                    $"{npcObject.Name}".PadRight(30) +
                    $"{npcObject.RoomLocationID}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += npcObjectRows;

            return messageBoxText;
        }

        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }


        public static string ListRoomLocationObjectsByRoomLocation(int roomLocationId, IEnumerable<GameObject> gameObjects)
        {
            //
            // generate a list of Hero objects from the game object list with the current room location id
            //
            List<RoomLocationObject> roomLocationObjects = new List<RoomLocationObject>();
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is HeroObject &&
                    gameObject.RoomLocationID == roomLocationId)
                {
                    roomLocationObjects.Add(gameObject as RoomLocationObject);
                }
            }

            //
            // display table name and column headers
            //
            string messageBoxText =
                "Space-Time Location Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Type".PadRight(20) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) +
                "----------------------".PadRight(20) + "\n";

            //
            // display all traveler objects in rows
            //
            string roomLocationObjectRows = null;
            foreach (RoomLocationObject roomLocationObject in roomLocationObjects)
            {
                roomLocationObjectRows +=
                    $"{roomLocationObject.Id}".PadRight(10) +
                    $"{roomLocationObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += roomLocationObjectRows;

            return messageBoxText;
        }

        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                " \n" +
                gameObject.Description + " \n" +
                " \n";

            if (gameObject is HeroObject)
            {
                HeroObject heroObject = gameObject as HeroObject;

                messageBoxText += $"The {heroObject.Name} has a value of {heroObject.Value} and ";

                if (heroObject.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }
                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else
            {
                messageBoxText += $"The {gameObject.Name} may not be added to your inventory.";
            }

            return messageBoxText;
        }

        public static string CurrentInventory(IEnumerable<HeroObject> inventory)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
            "ID".PadRight(10) +
            "Name".PadRight(30) +
            "Type".PadRight(10) +
            "\n" +
            "---".PadRight(10) +
            "----------------------------".PadRight(30) +
            "----------------------".PadRight(10) +
            "\n";

            //
            // display all traveler objects in rows
            //
            string inventoryObjectRows = null;
            foreach (HeroObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                    $"{inventoryObject.Id}".PadRight(10) +
                    $"{inventoryObject.Name}".PadRight(30) +
                    $"{inventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }

        public static string NpcsChooseList(IEnumerable<Npc> npcs)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "NPCs\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //
            // display all NPCs in rows
            //
            string npcRows = null;
            foreach (Npc npc in npcs)
            {
                npcRows +=
                    $"{npc.Id}".PadRight(10) +
                    $"{npc.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += npcRows;

            return messageBoxText;
        }

        #endregion

        public static List<string> StatusBox(Hero hero)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {hero.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {hero.Health}\n");
            statusBoxText.Add($"Lives: {hero.Lives}\n");

            return statusBoxText;
        }
    }
}
