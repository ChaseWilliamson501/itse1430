using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public static class SeedContactDatabase
    {
        public static void Seed( this IContactDatabase source )
        {
            //Collection initializer
            var games = new[]
                {
                    new Contact() { Name = "Michael",  Email = "michael.taylor769@my.tccd.edu",  },
                    new Contact() { Name = "Chase", Email = "chase.williamson667@my.tccd.edu", },
                    new Contact() { Name = "Dragonborn", Email = "DragonKilling101@gmail.com",  }
                };

            foreach (var contact in contacts)
                source.Add(contact);
        }
    }
}