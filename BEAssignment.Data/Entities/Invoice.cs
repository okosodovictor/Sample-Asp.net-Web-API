using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEAssignment.Data.Entities
{
   public class Invoice
    {
        [Key]
        public int InvoiceId {get; set;}
        public int AddressId {get; set;}
        public string InvoiceType { get; set; }
        public string invoiceTypeLocalized { get; set; }
        public DateTime? InvoiceDate { get; set;}
        public DateTime? PaymentDueDate { get; set;}
        public string InvoiceNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PeriodDescription { get; set; }

        public string Shop { get; set; }

        public decimal Amount { get; set; }

        public double VatAmount {get; set;}
        public virtual Address Address { get; set; }
    }
}
