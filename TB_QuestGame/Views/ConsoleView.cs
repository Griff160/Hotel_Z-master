using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// Console view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            HeroInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Hero _gameHero;
        Hotel _gameHotel;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Hero gameHero, Hotel gameHotel)
        {
            _gameHero = gameHero;
            _gameHotel = gameHotel;

            _viewStatus = ViewStatus.HeroInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public HeroAction GetActionMenuChoice(Menu menu)
        {
            HeroAction choosenAction = HeroAction.None;
            Console.CursorVisible = false;

            //
            // create an array of valid jeys from the menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        private bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            // validate on range if either minimumValue and maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false;

            return true;
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetDouble(string prompt, double minimumValue, double maximumValue, out double doubleChoice)
        {
            bool validResponse = false;
            doubleChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (double.TryParse(Console.ReadLine(), out doubleChoice))
                {
                    if (doubleChoice >= minimumValue && doubleChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an number value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an number value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.ClassType GetClass()
        {
            Character.ClassType classType;
            Enum.TryParse<Character.ClassType>(Console.ReadLine(), out classType);

            return classType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @"          _______ _________ _______  _          _______ ");
            Console.WriteLine(tabSpace + @"|\     /|(  ___  )\__   __/(  ____ \( \        / ___   )");
            Console.WriteLine(tabSpace + @"| )   ( || (   ) |   ) (   | (    \/| (        \/   )  |");
            Console.WriteLine(tabSpace + @"| (___) || |   | |   | |   | (__    | |            /   )");
            Console.WriteLine(tabSpace + @"|  ___  || |   | |   | |   |  __)   | |           /   / ");
            Console.WriteLine(tabSpace + @"| (   ) || |   | |   | |   | (      | |          /   /  ");
            Console.WriteLine(tabSpace + @"| )   ( || (___) |   | |   | (____/\| (____/\   /   (_/\");
            Console.WriteLine(tabSpace + @"|/     \|(_______)   )_(   (_______/(_______/  (_______/");
            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The Aion Project";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, HeroAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != HeroAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameHero))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>hero object with all properties updated</returns>
        public Hero GetInitialHeroInfo()
        {
            Hero hero = new Hero();

            //
            // intro
            //
            DisplayGamePlayScreen("Hero Creation", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get hero's name
            //
            DisplayGamePlayScreen("Hero Creation - Name", Text.InitializeMissionGetHeroName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            hero.Name = GetString();

            //
            // get hero's age
            //
            DisplayGamePlayScreen("Hero Creation - Age", Text.InitializeMissionGetHeroAge(hero), ActionMenu.MissionIntro, "");
            int gameHeroAge;

            GetInteger($"Enter your age {hero.Name}: ", 0, 150, out gameHeroAge);
            hero.Age = gameHeroAge;

            //
            // get hero's race
            //
            DisplayGamePlayScreen("Hero Creation - Class", Text.InitializeMissionGetHeroRace(hero), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your class {hero.Name}: ");
            hero.Class = GetClass();

            //
            // echo the hero's info
            //
            DisplayGamePlayScreen("Hero Creation - Complete", Text.InitializeMissionEchoHeroInfo(hero), ActionMenu.MissionIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return hero;
        }

        #region ----- display responses to menu action choices -----

        public void DisplayHeroInfo()
        {
            RoomLocation currentSpaceTimeLocation = _gameHotel.GetRoomLocationById(_gameHero.RoomLocationID);
            DisplayGamePlayScreen("Traveler Information", Text.TravelerInfo(_gameHero, currentSpaceTimeLocation), ActionMenu.HeroMenu, "");
        }

        /// <summary>
        /// display all relevant information about the current location
        /// </summary>
        public void DisplayCurrentLocationInfo()
        {
            RoomLocation currentRoomLocation = _gameHotel.GetRoomLocationById(_gameHero.RoomLocationID);
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentRoomLocation), ActionMenu.MainMenu, "");
        }

        public void DisplayListOfRoomLocations()
        {
            DisplayGamePlayScreen("List: Room Locations", Text.ListAllRoomLocations(_gameHotel.RoomLocations), ActionMenu.AdminMenu, "");
        }

        //
        // TODO fix game objects not being visible when looking around
        //
        public void DisplayLookAround()
        {
            //
            // get current room location
            //
            RoomLocation currentRoomLocation = _gameHotel.GetRoomLocationById(_gameHero.RoomLocationID);

            //
            // get list of game objects in current room location
            //
            List<GameObject> gameObjectsInCurrentRoomLocation = _gameHotel.GetGameObjectsByRoomLocationId(_gameHero.RoomLocationID);

            //
            // get list of NPCs in current room location
            //
            List<Npc> npcsInCurrentRoomLocation = _gameHotel.GetNpcsByRoomLocationId(_gameHero.RoomLocationID);

            string messageBoxText = Text.LookAround(currentRoomLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentRoomLocation) + Environment.NewLine;
            messageBoxText += Text.NpcsChooseList(npcsInCurrentRoomLocation);

            DisplayGamePlayScreen("Current Location:", messageBoxText, ActionMenu.MainMenu, "");
        }

        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.ObjectMenu, "");
        }

        public int DisplayGetHeroObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of hero objects in the current room location 
            //
            List<HeroObject> heroObjectsInRoomLocation = _gameHotel.GetHeroObjectsByRoomLocationId(_gameHero.RoomLocationID);

            if (heroObjectsInRoomLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(heroObjectsInRoomLocation), ActionMenu.ObjectMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameHotel.IsValidHeroObjectByLocationId(gameObjectId, _gameHero.RoomLocationID))
                    {
                        HeroObject heroObject = _gameHotel.GetGameObjectById(gameObjectId) as HeroObject;
                        if (heroObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you may not inventory that object. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }



        public int DisplayGetInventoryObjectToPutDown()
        {
            int heroObjectId = 0;
            bool validInventoryObjectId = false;

            if (_gameHero.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gameHero.Inventory), ActionMenu.ObjectMenu, "");

                while (!validInventoryObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to remove from your inventory: ", 0, 0, out heroObjectId);

                    //
                    // find object in inventory
                    // note: LINQ used, but a foreach loop may also be used 
                    //
                    HeroObject objectToPutDown = _gameHero.Inventory.FirstOrDefault(o => o.Id == heroObjectId);

                    //
                    // validate object in inventory
                    //
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the Id of an object not in the inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no objects currently in inventory.", ActionMenu.ObjectMenu, "");
            }

            return heroObjectId;
        }

        public int DisplayGetNextRoomLocation()
        {
            int roomLocationId = 0;
            bool validRoomLocationId = false;

            DisplayGamePlayScreen("Travel to a new Room", Text.Travel(_gameHero,
                _gameHotel.RoomLocations), ActionMenu.MainMenu, "");

            while (!validRoomLocationId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter your new location {_gameHero.Name}: ", 1, _gameHotel.GetMaxRoomLocationId(), out
                    roomLocationId);

                //
                // validate integer as a valid room location id and determine accessibility
                //
                if (_gameHotel.IsValidRoomLocationId(roomLocationId))
                {
                    if (_gameHotel.GetRoomLocationById(roomLocationId).Accessible)
                    {
                        validRoomLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you are attempting to travel to an inaccessible location. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("It appears you entered an invalid room location id. Please try again.");
                }
            }
            return roomLocationId;
        }

        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGamerObjectId = false;

            //
            // get a list of game objects in the current room location
            //
            List<GameObject> gameObjectsInRoomLocation = _gameHotel.GetGameObjectsByRoomLocationId(_gameHero.RoomLocationID);

            if (gameObjectsInRoomLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Object", Text.GameObjectsChooseList(gameObjectsInRoomLocation), ActionMenu.ObjectMenu, "");

                while (!validGamerObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameHotel.IsValidGameObjectByLocationId(gameObjectId, _gameHero.RoomLocationID))
                    {
                        validGamerObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no game objects here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        public void DisplayLocationsVisited()
        {
            //
            // generate a list of room locations that have been visited
            //
            List<RoomLocation> visitedRoomLocations = new List<RoomLocation>();
            foreach (int roomLocationId in _gameHero.RoomLocationsVisited)
            {
                visitedRoomLocations.Add(_gameHotel.GetRoomLocationById(roomLocationId));
            }
            DisplayGamePlayScreen("Rooms visited", Text.VisitedLocations
                (visitedRoomLocations), ActionMenu.HeroMenu, "");
        }

        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gameHero.Inventory), ActionMenu.HeroMenu, "");
        }

        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: GameObjects", Text.ListAllGameObjects(_gameHotel.GameObjects), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display a list of all npc objects
        /// </summary>
        public void DisplayListOfAllNpcObjects()
        {
            DisplayGamePlayScreen("List: Npc Objects", Text.ListAllNpcObjects(_gameHotel.Npcs), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display get the NPC to talk to
        /// </summary>
        /// <returns>NPC Id</returns>
        public int DisplayGetNpcToTalkTo()
        {
            int npcId = 0;
            bool validNpcId = false;

            //
            // get a list of NPCs in the current space-time location
            //
            List<Npc> npcsInSpaceTimeLocation = _gameHotel.GetNpcsByRoomLocationId(_gameHero.RoomLocationID);

            if (npcsInSpaceTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Speak With", Text.NpcsChooseList(npcsInSpaceTimeLocation), ActionMenu.NpcMenu, "");

                while (!validNpcId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the character you wish to speak with: ", 0, 0, out npcId);

                    //
                    // validate integer as a valid NPC id and in current location
                    //
                    if (_gameHotel.IsValidNpcByLocationId(npcId, _gameHero.RoomLocationID))
                    {
                        Npc npc = _gameHotel.GetNpcById(npcId);
                        if (npc is ISpeak)
                        {
                            validNpcId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears this character has nothing to say. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Speak With", "It appears there are no NPCs here.", ActionMenu.NpcMenu, "");
            }

            return npcId;
        }

        public void DisplayConfirmHeroObjectAddedToInventory(HeroObject objectAddedToInventory)
        {
            DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory.Name} has been added to your inventory.", ActionMenu.ObjectMenu, "");
        }

        public void DisplayConfirmHeroObjectRemovedFromInventory(HeroObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// display the message from the NPC
        /// </summary>
        /// <param name="npc">speaking NPC</param>
        public void DisplayTalkTo(Npc npc)
        {
            ISpeak speakingNpc = npc as ISpeak;

            string message = speakingNpc.Speak();

            if (message == "")
            {
                message = "It appears this character has nothing to say. Please try again.";
            }

            DisplayGamePlayScreen("Speak to Character", message, ActionMenu.NpcMenu, "");
        }

        #endregion

        #endregion
    }
}
