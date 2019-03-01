using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {

        public Character()
        {
            var x = 1 + 2;
        }

        public Character( string character )
        {
            Character = character;
        }

        public string Name
        {
            get ( return _character ?? " ";)
            set { _character = Value; }
        }

       private string _character = "";

        public string Professional { get; set; }
        public string Race { get; set; }

        public string Fighter { get; set; }
        public string Hunter { get; set; }
        public string Priest { get; set; }
        public string Rogue { get; set; }
        public string Wizard { get; set; }


        public string Dwarf { get; set; }
        public string Elf { get; set; }
        public string Gnome { get; set; }
        public string HalfElf { get; set; }
        public string Human { get; set; }


        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Chrisma { get; set; }

       public bool Valiate()
       {

           var str = this.Name;

           if (String.IsNullOrEmpty(Name))
             return false;

       }
    }
   
  
}
