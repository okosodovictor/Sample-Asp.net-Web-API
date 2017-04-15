using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEAssignment.Data.Entities
{
   public class Address
    {
        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public Address()
        {
            Invoices = new HashSet<Invoice>();
        }
    }
}
