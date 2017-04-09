using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{ 
    public static partial class HotelObjects
    {
        public static List<RoomLocation> RoomLocations = new List<RoomLocation>()
        {

            new RoomLocation
            {
                CommonName = "Floor 8",
                RoomLocationID = 1,
                HotelLocation = "Floor 8",
                Description = "The 8th floor of the hotel. It is going to be a tough " +
                    "ask to make it all the way to the street. Most of the rooms are inaccessible " +
                    "due to a collapsed roof.\n",
                GeneralContents = "There is not much of use on this floor. I wish I would " +
                    "have asked for a room on a lower floor. At least the zombies seem to not " +
                    "have made it up here yet. \n",
                Accessable = true,
                ExperiencePoints = 10,
                Lives = 0
            },

            new RoomLocation
            {
                CommonName = "Floor 7",
                RoomLocationID = 2,
                HotelLocation = "Floor 7",
                Description = "The 7th floor is full of what looks like rooms from a " +
                    "wedding party. There is a red shape in one of the rooms in the " +
                    "distance.",
                GeneralContents = "You can see what remains of a woman in a wedding dress, her remains half eaten." +
                    "There is nothing of use on her body though. ",
                Accessable = true,
                ExperiencePoints = 20,
                Lives = 0
            },

            new RoomLocation
            {
                CommonName = "Floor 6",
                RoomLocationID = 3,
                HotelLocation = "Floor 6",
                Description = "The 6th floor looks very similar to the others you have seen, " +
                              "will you ever make it to the exit? ",
                GeneralContents = "Most of the rooms are locked. There is a bell boy who is cowering in the corner. " +
                    "He is rocking back and forth talking about the terrifying zombies",
                Accessable = true,
                ExperiencePoints = 20,
                Lives = 0
            },

            new RoomLocation
            {
                CommonName = "Floor 5",
                RoomLocationID = 4,
                HotelLocation = "Floor 5",
                Description = "The 5th floor seems pretty boring... maybe I should look around. ",
                GeneralContents = "The floor ended up being boring. There was nothing of note here.",
                Accessable = true,
                ExperiencePoints = 10,
                Lives = 0
            },

            new RoomLocation
            {
                CommonName = "Floor 4",
                RoomLocationID = 5,
                HotelLocation = "Floor 4",
                Description = "I have a good feeling about this floor for some reason! ",
                GeneralContents = "You find a sandwich and gain 1 life! ",
                Accessable = true,
                ExperiencePoints = 100,
                Lives = 1
            },

            new RoomLocation
            {
                CommonName = "Floor 3",
                RoomLocationID = 6,
                HotelLocation = "Floor 3",
                Description = "Just a typical floor in an uneventful hotel. " ,
                GeneralContents = "Upon further inspection this floor is very eventful, considering there are " +
                    "almost 30 half eaten bodies around. ",
                Accessable = true,
                ExperiencePoints = 10,
                Lives = 0
            },

            new RoomLocation
            {
                CommonName = "Floor 2",
                RoomLocationID = 7,
                HotelLocation = "Floor 2",
                Description = "Almost to the ground floor!",
                GeneralContents = "You look in to the room and find a zombie who bites you! Removing a life from your total. ",
                Accessable = true,
                ExperiencePoints = -10,
                Lives = -1
            },

            new RoomLocation
            {
                CommonName = "Floor 1",
                RoomLocationID = 8,
                HotelLocation = "Floor 1",
                Description = "One more floor to go. I hope nothing bad will happen to me now that im this close. ",
                GeneralContents = "You look in to the room and find a zombie who bites you! Removing a life from your total. ",
                Accessable = true,
                ExperiencePoints = 10,
                Lives = -1
            },

            new RoomLocation
            {
                CommonName = "Ground Floor",
                RoomLocationID = 9,
                HotelLocation = "Ground Floor",
                Description = "This is the exit!",
                GeneralContents = "Now lets see if i can survive outside...",
                Accessable = false,
                ExperiencePoints = 10000,
                Lives = 0
            }
        };

    }
}
