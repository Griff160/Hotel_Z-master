using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum ClassType
        {
            None,
            Boxer,
            Athlete,
            Dog,
            Student,
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _roomLocationID;
        private int _age;
        private ClassType _race;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int RoomLocationID
        {
            get { return _roomLocationID; }
            set { _roomLocationID = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public ClassType Class
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, ClassType race, int roomLocationID)
        {
            _name = name;
            _race = race;
            _roomLocationID = roomLocationID;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
