using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEAssignment.Core.Business;
using BEAssignmentSolution.Core.Business;
using System.ComponentModel.DataAnnotations;

namespace BEAssignment.Core.Business
{
   public class InvoiceModel: Model
    {
        public int InvoiceId { get; set; }
        public int AddressId { get; set; }
        public string InvoiceType { get; set; }
        public string invoiceTypeLocalized { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        [Required]
        public string InvoiceNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string PeriodDescription { get; set; }

        public decimal Amount { get; set; }

        public double VatAmount { get; set; }

        public virtual AddressModel Address { get; set; }
        public virtual CustomerModel customer { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AddressId == 0) yield return new ValidationResult("Invalid Address ID", new[] { "AddressId" });


        }
    }
}
