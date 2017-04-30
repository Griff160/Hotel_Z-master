﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class HotelObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            //TODO update npc info
            
            new Guest
            {
                Id = 1,
                Name = "Man with Stripped Hat",
                RoomLocationID = 2,
                Description = "A tall man in baggy pants with a red, pin stripped hat.",
                Messages = new List<string>
                {
                    "Greetings stranger. You are not from these parts as I can see.",
                    "You will find what you are looking for with the Pink Gorilla.",
                    "I once attended the Academy. They felt I needed more candles."
                }
            },

            new Guest
            {
                Id = 2,
                Name = "Timothy Sargent",
                RoomLocationID = 1,
                Description = "The lead developer of the Stratus Flux Capacitor.",
                Messages = new List<string>
                {
                    "I have to go. Good bye!",
                    "It was always meant for good. We had no idea.",
                    "Is that man following you?"
                }
            },

            new Guest
            {
                Id = 3,
                Name = "Thorian Diplomat",
                RoomLocationID = 2,
                Description = "A Thorian diplomat dressed in traditional phlox and cords."
            }
        };
    }
}
