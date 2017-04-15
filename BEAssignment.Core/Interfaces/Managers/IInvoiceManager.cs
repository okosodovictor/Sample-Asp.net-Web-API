using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEAssignment.Core.Business;

namespace BEAssignment.Core.Interfaces.Managers
{
   public interface IInvoiceManager
    {
        Operation<InvoiceModel[]> GetInvoiceByCustomerIdAndMonth(int customerId, int month);
        Operation<InvoiceModel[]> GetInvoiceByCustomerIdFilterAndMonth(int customerId, string filter, int month);
        Operation<InvoiceModel[]> GetInvoiceByCustomerIdAndAddres(int customerId, int addressId);
        Operation<InvoiceModel[]> GetInvoiceByCustomerId(int customerId);
        Operation<InvoiceModel[]> GetInvoiceByAddressId(int addressId);
        Operation<InvoiceModel> CreateInvoice(InvoiceModel model);
    }
}
