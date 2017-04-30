using System;
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
            
            new Guest
            {
                Id = 1,
                Name = "Juilana",
                RoomLocationID = 2,
                ExperiencePoints =100,
                Description = "A woman with long straight red hair.",
                Messages = new List<string>
                {
                    "They came from nowhere attacking everyone.",
                    "We are all doomed..."
                }
            },

            new Guest
            {
                Id = 2,
                Name = "Asher",
                RoomLocationID = 1,
                Description = "A rugged looking man with a broken leg.",
                Messages = new List<string>
                {
                    "If this leg wasn't busted I would make it out for sure!",
                    "This thing hurts like hell.",
                }
            },

            new Guest
            {
                Id = 3,
                Name = "Leo",
                RoomLocationID = 5,
                Description = "A man with his tongue cut out. Ouch!"
            },

            new Guest
            {
                Id = 4,
                Name = "Christiana",
                RoomLocationID = 6,
                Description = "A young woman who looks lost.",
                Messages = new List<string>
                {
                    "Was I already here before?",
                    "these floors look so similar..."
                }
            },

            new Guest
            {
                Id = 5,
                Name = "Beatrix",
                RoomLocationID = 4,
                Description = "A woman arguing with her spouse.",
                Messages = new List<string>
                {
                    "Can't you see that I cannot talk to you right now."
                }
            },
            new Guest
            {
                Id = 6,
                Name = "Tim",
                RoomLocationID = 4,
                Description = "A man arguing with his spouse.",
                Messages = new List<string>
                {
                    "Leave me alone."
                }
            }
        };
    }
}
