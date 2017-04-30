using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Hero _gameHero;
        private Hotel _gameHotel; 
        private bool _playingGame;
        private RoomLocation _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameHero = new Hero();
            _gameHotel = new Hotel();
            _gameConsoleView = new ConsoleView(_gameHero, _gameHotel);
            _playingGame = true;

            //
            // add initial items to the hero's inventory
            //
            _gameHero.Inventory.Add(_gameHotel.GetGameObjectById(8) as HeroObject);
            _gameHero.Inventory.Add(_gameHotel.GetGameObjectById(9) as HeroObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            HeroAction heroActionChoice = HeroAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission hero
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameHotel.GetRoomLocationById(_gameHero.RoomLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                heroActionChoice = GetNextHeroAction();

                //
                // choose an action based on the user's menu choice
                //
                switch (heroActionChoice)
                {
                    case HeroAction.None:
                        break;

                    case HeroAction.HeroInfo:
                        _gameConsoleView.DisplayHeroInfo();
                        break;

                    case HeroAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case HeroAction.Travel:
                        TravelAction();
                        break;

                    case HeroAction.HeroLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case HeroAction.LookAt:
                        LookAtAction();
                        break;

                    case HeroAction.PickUp:
                        PickUpAction();
                        break;

                    case HeroAction.PutDown:
                        PutDownAction();
                        break;

                    case HeroAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case HeroAction.TalkTo:
                        TalkToAction();
                        break;

                    case HeroAction.ListRoomLocations:
                        _gameConsoleView.DisplayListOfRoomLocations();
                        break;

                    case HeroAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case HeroAction.ListNonplayerCharacters:
                        _gameConsoleView.DisplayListOfAllNpcObjects();
                        break;

                    case HeroAction.HeroMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.HeroMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Hero Menu", "Select an operation from the menu.", ActionMenu.HeroMenu, "");
                        break;

                    case HeroAction.ObjectMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an operation from the menu.", ActionMenu.ObjectMenu, "");
                        break;

                    case HeroAction.NonplayerCharacterMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
                        break;

                    case HeroAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case HeroAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case HeroAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// display the correct menu/sub-menu and get the next traveler action
        /// </summary>
        /// <returns>traveler action</returns>
        private HeroAction GetNextHeroAction()
        {
            HeroAction heroActionChoice = HeroAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    heroActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;

                case ActionMenu.CurrentMenu.ObjectMenu:
                    heroActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;

                case ActionMenu.CurrentMenu.NpcMenu:
                    heroActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;

                case ActionMenu.CurrentMenu.HeroMenu:
                    heroActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.HeroMenu);
                    break;

                case ActionMenu.CurrentMenu.AdminMenu:
                    heroActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;

                default:
                    break;
            }

            return heroActionChoice;
        }

        /// <summary>
        /// process the Travel action
        /// </summary>
        private void TravelAction()
        {
            //
            // get new location choice and update the current location property
            //                        
            _gameHero.RoomLocationID = _gameConsoleView.DisplayGetNextRoomLocation();
            _currentLocation = _gameHotel.GetRoomLocationById(_gameHero.RoomLocationID);

            //
            // display the new room location info
            //
            _gameConsoleView.DisplayCurrentLocationInfo();
        }

        /// <summary>
        /// process the Look At action
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of game objects in room location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameHotel.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        /// <summary>
        /// process the Pick Up action
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of hero objects in room location and get a player choice
            //
            int heroObjectToPickUpId = _gameConsoleView.DisplayGetHeroObjectToPickUp();

            //
            // add the hero object to hero's inventory
            //
            if (heroObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                HeroObject heroObject = _gameHotel.GetGameObjectById(heroObjectToPickUpId) as HeroObject;

                //
                // note: hero object is added to list and the room location is set to 0
                //
                _gameHero.Inventory.Add(heroObject);
                heroObject.RoomLocationID = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmHeroObjectAddedToInventory(heroObject);
            }
        }

        /// <summary>
        /// process the Put Down action
        /// </summary>
        private void PutDownAction()
        {
            //
            // display a list of hero objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the universe
            //
            HeroObject heroObject = _gameHotel.GetGameObjectById(inventoryObjectToPutDownId) as HeroObject;

            //
            // remove the object from inventory and set the room location to the current value
            //
            _gameHero.Inventory.Remove(heroObject);
            heroObject.RoomLocationID = _gameHero.RoomLocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmHeroObjectRemovedFromInventory(heroObject);

        }

        /// <summary>
        /// process the Talk To action
        /// </summary>
        private void TalkToAction()
        {
            //
            // display a list of NPCs in room location and get a player choice
            //
            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            //
            // display NPC's message
            //
            if (npcToTalkToId != 0)
            {
                //
                // get the NPC from the universe
                //
                Npc npc = _gameHotel.GetNpcById(npcToTalkToId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayTalkTo(npc);
            }
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Hero hero = _gameConsoleView.GetInitialHeroInfo();

            _gameHero.Name = hero.Name;
            _gameHero.Age = hero.Age;
            _gameHero.Class = hero.Class;
            _gameHero.RoomLocationID = 1;

            _gameHero.ExperiencePoints = 0;
            _gameHero.Health = 100;
            _gameHero.Lives = 3;
        }

        private void UpdateGameStatus()
        {
            if (!_gameHero.HasVisited(_currentLocation.RoomLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _gameHero.RoomLocationsVisited.Add(_currentLocation.RoomLocationID);

                //
                // update experience points for visiting locations
                //
                _gameHero.ExperiencePoints += _currentLocation.ExperiencePoints;

                //
                // update lives for visiting locations
                //
                _gameHero.Lives += _currentLocation.Lives;

                //
                // update experience points for talking to npcs
                //
                    //_gameHero.ExperiencePoints += _currentNpc.ExperiencePoints;
                //
                // update lives for talking to npcs
                //
                    //_gamehero.Lives += _currentNpc.Lives;
            }
            //if (_gameHero.Inventory.Contains())
            //{

            //}
        }

        #endregion
    }
}
