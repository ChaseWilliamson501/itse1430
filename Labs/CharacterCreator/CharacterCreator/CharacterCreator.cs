using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        public string Name { get; set; }
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
    }
   

}
