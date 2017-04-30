using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Hotel
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all room locations
        //
        private List<RoomLocation> _roomLocations;
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;

        public List<RoomLocation> RoomLocations
        {
            get { return _roomLocations; }
            set { _roomLocations = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }

        #endregion

        #region ***** constructor *****

        //
        // default Hotel constructor
        //
        public Hotel()
        {
            //
            // add all of the hotel objects to the game
            // 
            IntializeHotel();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the Hotel with all of the room locations
        /// </summary>
        private void IntializeHotel()
        {
            _roomLocations = HotelObjects.RoomLocations;
            _gameObjects = HotelObjects.gameObjects;
            _npcs = HotelObjects.Npcs;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// determine if the room Location Id is valid
        /// </summary>
        /// <param name="roomLocationId">true if Room Location exists</param>
        /// <returns></returns>
        public bool IsValidRoomLocationId(int roomLocationId)
        {
            List<int> roomLocationIds = new List<int>();

            //
            // create a list of room location ids
            //
            foreach (RoomLocation stl in _roomLocations)
            {
                roomLocationIds.Add(stl.RoomLocationID);
            }

            //
            // determine if the room location id is a valid id and return the result
            //
            if (roomLocationIds.Contains(roomLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentRoomLocation)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // create a list of game object ids in current room location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.RoomLocationID == currentRoomLocation)
                {
                    gameObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// validate hero object id number in current location
        /// </summary>
        /// <param name="HeroObjectId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidHeroObjectByLocationId(int HeroObjectId, int currentRoomLocation)
        {
            List<int> HeroObjectIds = new List<int>();

            //
            // create a list of Hero object ids in current room location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.RoomLocationID == currentRoomLocation && gameObject is HeroObject)
                {
                    HeroObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (HeroObjectIds.Contains(HeroObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// validate NPC object id number in current location
        /// </summary>
        /// <param name="npcId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidNpcByLocationId(int npcId, int currentRoomLocation)
        {
            List<int> npcIds = new List<int>();

            //
            // create a list of NPC ids in current space-time location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.RoomLocationID == currentRoomLocation)
                {
                    npcIds.Add(npc.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="roomLocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int roomLocationId)
        {
            RoomLocation roomLocation = GetRoomLocationById(roomLocationId);
            if (roomLocation.Accessible == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return the next available ID for a RoomLocation object
        /// </summary>
        /// <returns>next RoomLocationObjectID </returns>
        public int GetMaxRoomLocationId()
        {
            int MaxId = 0;

            foreach (RoomLocation roomLocation in RoomLocations)
            {
                if (roomLocation.RoomLocationID > MaxId)
                {
                    MaxId = roomLocation.RoomLocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a RoomLocation object using an Id
        /// </summary>
        /// <param name="Id">room location ID</param>
        /// <returns>requested room location</returns>
        public RoomLocation GetRoomLocationById(int Id)
        {
            RoomLocation roomLocation = null;

            //
            // run through the room location list and grab the correct one
            //
            foreach (RoomLocation location in _roomLocations)
            {
                if (location.RoomLocationID == Id)
                {
                    roomLocation = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw an exception
            //
            if (roomLocation == null)
            {
                string feedbackMessage = $"The Room {Id} does not exist in the hotel.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return roomLocation;
        }

        /// <summary>
        /// get a game object using an Id
        /// </summary>
        /// <param name="Id">game object Id</param>
        /// <returns>requested game object</returns>
        public GameObject GetGameObjectById(int Id)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {Id} does not exist.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return gameObjectToReturn;
        }

        public List<GameObject> GetGameObjectsByRoomLocationId(int roomLocationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // run through the game object list and grab all that are in the current room location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.RoomLocationID == roomLocationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        public List<HeroObject> GetHeroObjectsByRoomLocationId(int roomLocationId)
        {
            List<HeroObject> heroObjects = new List<HeroObject>();

            //
            // run through the game object list and grab all that are in the current room location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.RoomLocationID == roomLocationId && gameObject is HeroObject)
                {
                    heroObjects.Add(gameObject as HeroObject);
                }
            }

            return heroObjects;
        }

        /// <summary>
        /// get an NPC object using an Id
        /// </summary>
        /// <param name="Id">NPC object Id</param>
        /// <returns>requested NPC object</returns>
        public Npc GetNpcById(int Id)
        {
            Npc npcToReturn = null;

            //
            // run through the NPC object list and grab the correct one
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return npcToReturn;
        }

        /// <summary>
        /// get all NPC objects in a location
        /// </summary>
        /// <param name="roomLocationId">space-time location id</param>
        /// <returns>list of NPC objects</returns>
        public List<Npc> GetNpcsByRoomLocationId(int roomLocationId)
        {
            List<Npc> npcs = new List<Npc>();

            //
            // run through the NPC object list and grab all that are in the current room location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.RoomLocationID == roomLocationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        #endregion


    }
}
