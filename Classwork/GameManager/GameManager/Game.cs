using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager
{
   
    /// <summary>Represents a game.</summary>
    public class Game
    {
        public int Id { get; set; }
        //Ctors

        // Default, no return type
        // 1)Cannot be called directly
        // 2)Errors are very bad
        // 3)Should behave no different than doing manually

        public Game()
        {
            //Complex init
            var x = 1 + 2;
        }

        //Constructor chaining
        public Game (string name) : this(name, 0)
        {
               //Name = name;
        }

        // As soon as you define a ctor, no default ctor anymore
        public Game (string name, decimal price) // : this()
        {
            Name = name;
        }
        /// <summary>Name of the game.</summary> 
        public string Name
        {
            get { return _name ?? " "; }
            set { _name = value; }
        }

        private string _name = "";


        /// <summary>Publisher of the game.</summary>
        public string Publisher
        {
            get { return _publisher ?? ""; }
            set { _publisher = value; }
        }
        private string _publisher = "";

        //Calulated property
        public bool IsCoolGame
        {
            get { return Publisher != "EA"; }
        }
          
        //Setter only
        //public string Password
        //{
        //    set { }
        //}

            public decimal Price { get; set; }

        //public decimal Price
        //{
        //    get { return _price; }
        //    set { _price = value; }
        //}
        //private decimal _price;


        public bool Owned { get; set; } = true;

        public bool Completed { get; set; }

        //Mixed accessibility
        public double Rate
        {
            get;
            internal set;
        }

        public void Foo ()
        {
            //Not Deterministic - should have been a method
            var now = DateTime.Now;
        }

        public override string ToString()
        {
            return Name;
        }

        //Can init the data as well
        //public string[] Genres { get; set; }


        //private string[] Genres
        //{
        //    get 
        //    {
        //        var temp = new string[_genres.Length];
        //        Array.Copy(_genres, temp, _genres.Length);
        //        return temp;

        //    }
        //}
        //private string[] _genres;
        //public string[] genres = new string[10];
        //private decimal realPrice = Price;

        /// <summary>Validate the object
        /// <returns></returns>
        public bool Validate (/* Game this */)
        {
            //Redundant dude
            var str = this.Name;

            // Name is required
           if (String.IsNullOrEmpty(Name))
                return false;

            // Price >= 0
            if (Price < 0)
                return false;

            //Only if you need to pass the instance to someboby else
            //MyType.foo(this);

            return true;

        }
    }
}
