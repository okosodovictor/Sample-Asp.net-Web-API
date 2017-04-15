using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEAssignmentSolution.Core.Business
{
  public  class Model: IValidatableObject
    {
        public Operation<ValidationResult[]> Validate()
        {
            var errors = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, new ValidationContext(this, serviceProvider: null, items: null), errors, true);
            return new Operation<ValidationResult[]>
            {
                Result = errors.ToArray(),
                Succeeded = errors.Any() == false,
                Message = errors.Any() ? errors.Select(e => e.ErrorMessage).Aggregate((ag, e) => ag + ", " + e) : ""
            };

        }
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            return errors;
        }
    }
}
