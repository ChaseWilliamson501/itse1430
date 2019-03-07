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
        //{
        //    get { return _publisher ?? ""; }
        //    set { _publisher = value; }
        //}
        //private string _publisher = "";

        public string Race { get; set; }



      


        public int Strength { get; set; }
        //{
         //public decimal Price
        //{
        //    get { return _price; }
        //    set { _price = value; }
        //}
        //private decimal _price;

        // }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Chrisma { get; set; }


        //public Character()
        //{
           
        //}


       // Constructor 
        //public Character( string name, int Strength, int Intelligence, int Agility, int Constitution, int Chrisma) // : this()
        //{
        //    Name = name;
        //}
       

        //Calulated property
        public bool IsCoolCharacter
        {
            get { return Profession != "Fighter"; }
        }


        public void Foo()
        {
            //Not Deterministic - should have been a method
            var now = DateTime.Now;
        }

        public override string ToString()
        {
            return Name;
        }
 

        /// <summary>Validate the object
        /// <returns></returns>
        public bool Validate(/* Game this */)
        {
            //Redundant dude
            var str = this.Name;

            // Name is required
            if (String.IsNullOrEmpty(Name))
                return false;

            // Price >= 0
            //if (Price < 0)
                return false;

            //Only if you need to pass the instance to someboby else
            //MyType.foo(this);

            return true;

        }
    }
}

    
   


