using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Message : IValidatableObject
    {
        /// <summary>
        /// The contact part of your message
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// The subject part of your message
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The body(message itself) part of your message
        /// </summary>
        public string Body { get; set; }

        public Message()
        {

        }

        public Message( string subject, string message )
        {
            Subject = subject;
            Body = message;
        }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var items = new List<ValidationResult>();

            // Contact is required
            if (String.IsNullOrEmpty(Subject))
                items.Add(new ValidationResult("Contact is required.", new[] { nameof(Subject) }));

            // Subject is required
            if (String.IsNullOrEmpty(Subject))
                items.Add(new ValidationResult("Name is required.", new[] { nameof(Subject) }));

            // Body is required
            if (String.IsNullOrEmpty(Subject))
                items.Add(new ValidationResult("Body is required.", new[] { nameof(Body) }));

            return items;
        }
    }
}
