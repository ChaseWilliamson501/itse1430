using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        /// <summary>Name of the Character.</summary> 
        public string Name { get; set; }
        //{
        //  get { return _name ?? " "; }
        //  set { _name = value; }
        //}
        //private string _name = "";


/// <summary>Profession of the Character.</summary>
public string Profession { get; set; }
        //    {
        //        get { return _Profession ?? ""; }
        //        set { _Profession = value; }
        //    }
        //    private string _Profession = "";

        /// <summary>
        /// Name of the Race.
        /// </summary>
        public string Race { get; set; }

        //{
        //    get { return _race ?? ""; }
        //    set { _race = value; }
        //}
        //private string _race = "";

        /// <summary>
        /// Name of the Strength.
        /// </summary>
        public int Strength { get; set; }

        //{
        //    get { return _strength; }
        //    set { _strength = value; }
        //}
        //private decimal _strength = "";


        /// <summary>
        /// Name of the Intelligence.
        /// </summary>
        public int Intelligence { get; set; }

        //{
        //    get { return _intelligence; }
        //    set { _intelligence = value; }
        //}
        //private decimal _intelligence = "";

        /// <summary>
        /// Name of the Agility.
        /// </summary>
        public int Agility { get; set; }

        //{
        //    get { return _agility; }
        //    set { _agility = value; }
        //}
        //private int _agility = "";

        /// <summary>
        /// Name of the Constitution.
        /// </summary>
        public int Constitution { get; set; }

        //{
        //    get { return _constitution; }
        //    set { _constitution = value; }
        //}
        //private decimal _constitution = "";

        /// <summary>
        /// Name of the Charisma.
        /// </summary>
        public int Charisma { get; set; }

        //{
        //    get { return _Charisma; }
        //    set { _charisma = value; }
        //}
        //private int _charisma = "";


        public Character()
        {

        }


        //Constructor
        public Character( string name, int Strength, int Intelligence, int Agility, int Constitution, int Chrisma ) // : this()
        {
            Name = name;
        }


        public override string ToString()
        {
            return Name;
        }
 

        /// <summary>Validate the object
        /// <returns></returns>
        public bool Validate(/* Game this */)
        {

            // Name is required
            if (String.IsNullOrEmpty(Name))
                return false;

           
            if (Strength < 1 || Strength > 100)
                return false;

            if (Intelligence < 0)
                return false;

            if (Agility < 0)
                return false;

            if (Constitution < 0)
                return false;

            if (Charisma < 0)
                return false;

            return true;

        }
    }
}

    
   


