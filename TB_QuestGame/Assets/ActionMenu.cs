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
                    { '1', HeroAction.HeroInfo },
                    { '2', HeroAction.LookAround },
                    { '3', HeroAction.LookAt },
                    { '4', HeroAction.PickUp },
                    { '5', HeroAction.PutDown },
                    { '6', HeroAction.Inventory },
                    { '7', HeroAction.Travel },
                    { '8', HeroAction.HeroLocationsVisited },
                    { '9', HeroAction.AdminMenu },
                    { '0', HeroAction.Exit },
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, HeroAction>()
                {
                    { '1', HeroAction.ListRoomLocations },
                    { '2', HeroAction.ListGameObjects },
                    { '3', HeroAction.ReturnToMainMenu }
                }
        };

        
    }
}
