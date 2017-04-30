using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum HeroAction
    {
        None,
        MissionSetup,
        LookAround,
        Travel,

        HeroMenu,
        HeroInfo,
        Inventory,
        HeroLocationsVisited,

        ObjectMenu,
        LookAt,
        PickUp,
        PutDown,

        NonplayerCharacterMenu,
        TalkTo,

        AdminMenu,
        ListRoomLocations,
        ListGameObjects,
        ListNonplayerCharacters,

        ReturnToMainMenu,
        Exit
    }
}
