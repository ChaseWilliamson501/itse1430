using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }

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


    
    public class Message
    {

        public string Contact { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }

    public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
    {
        var items = new List<ValidationResult>();

        // Name is required
        if (String.IsNullOrEmpty(Name))
            items.Add(new ValidationResult("Name is required.", new[] { nameof(Name) }));

        // Price >= 0
        if (Price < 0)
            items.Add(new ValidationResult("Price must be >= 0.", new[] { nameof(Price) }));


        return items;
    }
  }
}



