using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    class ObjectValidator
    {
        public static class ObjectValidator
        {
            /// <summary>Validates an object.</summary>
            /// <param name="value">The object to validate.</param>
            /// <exception cref="ValidationException">The value is invalid.</exception>
            public static void Validate( IValidatableObject value )
            {
                Validator.ValidateObject(value, new ValidationContext(value), true);
                
            }

            
        }
    }
}
