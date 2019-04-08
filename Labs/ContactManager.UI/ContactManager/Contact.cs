using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Contact : IValidatableObject
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public int Id { get; set; }

    

    public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
    {
        var items = new List<ValidationResult>();

        // Name is required
        if (String.IsNullOrEmpty(Name))
            items.Add(new ValidationResult("Name is required.", new[] { nameof(Name) }));

        if (String.IsNullOrEmpty(Email))
             items.Add(new ValidationResult("Name is required.", new[] { nameof(Email) }));



            return items;
    }
  }
}



