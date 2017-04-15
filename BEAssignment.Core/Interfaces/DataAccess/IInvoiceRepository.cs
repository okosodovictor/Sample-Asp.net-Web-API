using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BEAssignment.Core.Business;

namespace BEAssignment.Core.Interfaces.DataAccess
{
    public interface IInvoiceRepository
    {
        InvoiceModel  CreateInvoice(InvoiceModel model);
        InvoiceModel[] GetInvoicesByCustomerId(int customerId);
        InvoiceModel[] GetInvoiceByCustomerIdAndAddress(int customerId, int addressId);
        InvoiceModel[] GetInvoiceByCustomerIdAndMonth(int customerId, int month);
        InvoiceModel[] GetInvoiceByAddressId(int addressId);
        InvoiceModel[] GetInvoiceByCustomerIdFilterAndMonth(int customerId, string filter, int month);
    }
}
