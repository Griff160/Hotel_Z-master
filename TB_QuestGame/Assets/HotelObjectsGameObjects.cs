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
 
        //
        // TODO change item info
        //
        public static partial class HotelObjects
        {
            public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new HeroObject
            {
                Id = 1,
                Name = "Bag of Gold",
                RoomLocationID = 2,
                Description = "A small leather pouch filled with 9 gold coins.",
                Type = HeroObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 2,
                Name = "Ruby of Saron",
                RoomLocationID = 3,
                Description = "A bright red jewel, roughly the size of a robin's egg.",
                Type = HeroObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 3,
                Name = "Rotogenic Medicine",
                RoomLocationID = 3,
                Description = "A wooden box containing a small vial filled with a blue liquid.",
                Type = HeroObjectType.Medicine,
                Value = 45,
                CanInventory = false,
                IsConsumable = true,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 4,
                Name = "Norlan Document ND-3075",
                RoomLocationID = 3,
                Description =
                    "Memo: Origin Errata" + "/n" +
                    "Universal Date: 378598" + "/n" +
                    "/n" +
                    "It appears a potential origin for the technology is based on Plenatia 5 in the Star Reach Galaxy.",
                Type = HeroObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 8,
                Name = "Aion Tracker",
                RoomLocationID = 0,
                Description =
                    "Standard issue device worn around wrist that allows for tracking and messaging.",
                Type = HeroObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 9,
                Name = "RatPak 47",
                RoomLocationID = 0,
                Description =
                    "Standard issue ration package contain nutrients for 72 hours.",
                Type = HeroObjectType.Food,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new HeroObject
            {
                Id = 5,
                Name = "Boldendorian Chest",
                RoomLocationID = 2,
                Description = "A large wooden chest adorned with jewels.",
                //IsDeadly = true
            },

            new HeroObject
            {
                Id = 6,
                Name = "Silver Mirror",
                RoomLocationID = 2,
                Description = "A small silver mirror hanging on the wall next to a small window.",
                //IsDeadly = true
            }
            };
        }
}
