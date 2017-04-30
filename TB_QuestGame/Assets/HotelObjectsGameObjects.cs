using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
        /// <summary>
        /// static class to hold objects in the game universe
        /// </summary>
 
        public static partial class HotelObjects
        {
            public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new HeroObject
            {
                Id = 1,
                Name = "Bleach",
                RoomLocationID = 2,
                Description = "Common household bleach. This could purify drinking water.",
                Type = HeroObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 2,
                Name = "Towel",
                RoomLocationID = 3,
                Description = "Always know where your towel is.",
                Type = HeroObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true               
            },

            new HeroObject
            {
                Id = 3,
                Name = "Hammer",
                RoomLocationID = 3,
                Description = "A claw hammer.",
                Type = HeroObjectType.Weapon,
                Value = 45,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 4,
                Name = "Lobby Door Code",
                RoomLocationID = 3,
                Description = "445552",                    
                Type = HeroObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 8,
                Name = "Cell Phone",
                RoomLocationID = 0,
                Description =
                    "Now if only I could find some service for this thing.",
                Type = HeroObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 9,
                Name = "Snack bars",
                RoomLocationID = 0,
                Description =
                    "Some terrible tasting food bars.",
                Type = HeroObjectType.Food,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 5,
                Name = "Treasure Chest",
                RoomLocationID = 2,
                Description = "A large wooden chest adorned with jewels. Why is this in a hotel?",
                //IsDeadly = true
            },

            new HeroObject
            {
                Id = 6,
                Name = "Vanity Mirror",
                RoomLocationID = 2,
                Description = "A mirror hanging on the wall next to a small window.",
                //IsDeadly = true
            }
            };
        }
}
