using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEAssignment.Core;
using BEAssignment.Core.Business;

namespace BEAssignmentSolution.Core.Business
{
   public class AddressModel:Model
    {
         public int AddressId { get; set; }
        public string AddressName { get; set; }
        public int CustomerID { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public virtual InvoiceModel Invoice { get; set; }
    }
}
