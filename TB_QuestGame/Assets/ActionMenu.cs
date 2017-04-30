using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public enum CurrentMenu
        {
            MissionIntro,
            InitializeMission,
            MainMenu,
            ObjectMenu,
            NpcMenu,
            HeroMenu,
            AdminMenu
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, HeroAction>()
                    {
                        { ' ', HeroAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, HeroAction>()
                {
                    { '1', HeroAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, HeroAction>()
                {
                    { '1', HeroAction.LookAround },
                    { '2', HeroAction.Travel },
                    { '3', HeroAction.ObjectMenu },
                    { '4', HeroAction.NonplayerCharacterMenu},
                    { '5', HeroAction.HeroMenu},
                    { '6', HeroAction.AdminMenu },
                    { '0', HeroAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, HeroAction>()
                {
                    { '1', HeroAction.ListRoomLocations },
                    { '2', HeroAction.ListGameObjects},
                    { '3', HeroAction.ListNonplayerCharacters},
                    { '0', HeroAction.ReturnToMainMenu }
                }
        };

        public static Menu HeroMenu = new Menu()
        {
            MenuName = "HeroMenu",
            MenuTitle = "Hero Menu",
            MenuChoices = new Dictionary<char, HeroAction>()
                {
                    { '1', HeroAction.HeroInfo },
                    { '2', HeroAction.Inventory},
                    { '3', HeroAction.HeroLocationsVisited},
                    { '0', HeroAction.ReturnToMainMenu }
                }
        };

        public static Menu ObjectMenu = new Menu()
        {
            MenuName = "ObjectMenu",
            MenuTitle = "Object Menu",
            MenuChoices = new Dictionary<char, HeroAction>()
                {
                    { '1', HeroAction.LookAt },
                    { '2', HeroAction.PickUp},
                    { '3', HeroAction.PutDown},
                    { '0', HeroAction.ReturnToMainMenu }
                }
        };

        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, HeroAction>()
                {
                    { '1', HeroAction.TalkTo},
                    { '0', HeroAction.ReturnToMainMenu }
                }
        };


    }
}
