using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Hero : Character
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        private int _experiencePoints;
        private int _health;
        private int _lives;
        private List<int> _roomLocationsVisited;
        private List<HeroObject> _inventory;


        #endregion

        #region PROPERTIES

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }

        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public List<int> RoomLocationsVisited
        {
            get { return _roomLocationsVisited; }
            set { _roomLocationsVisited = value; }
        }

        public List<HeroObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Hero()
        {
            _roomLocationsVisited = new List<int>();
            _inventory = new List<HeroObject>();
        }

        public Hero(string name, ClassType race, int roomLocationID) : base(name, race, roomLocationID)
        {
            _roomLocationsVisited = new List<int>();
            _inventory = new List<HeroObject>();
        }

        #endregion

        #region METHODS

        public bool HasVisited(int _roomLocationID)
        {
            if (RoomLocationsVisited.Contains(_roomLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
