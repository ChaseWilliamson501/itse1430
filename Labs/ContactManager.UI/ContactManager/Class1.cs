using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Contact
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public bool Validate()
        {

            // Name is required
            if (String.IsNullOrEmpty(Name))
                return false;

            return true;
            

        }
        bool IsValidEmail( string source )
        {
            try
            {
                new System.Net.Mail.MailAddress(source);
                return true;
            } catch
            { };

            return false;
        }

    }
}
