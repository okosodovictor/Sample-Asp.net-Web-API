using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEAssignmentSolution.Core.Business;

namespace BEAssignment.Core.Business
{
   public class CustomerModel :Model
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }

        public IEnumerable<InvoiceModel> Invoices { get; set; }

        public CustomerModel()
        {
            Addresses = new HashSet<AddressModel>();
            Invoices = new HashSet<InvoiceModel>();
        }
    }
}
