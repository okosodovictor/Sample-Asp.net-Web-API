using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEAssignment.Core.Business;
using BEAssignment.Core.Interfaces.DataAccess;
using BEAssignment.Core.Interfaces.Managers;

namespace BEAssignment.Core.Managers
{
    public class InvoiceManager : IInvoiceManager
    {

        private readonly IInvoiceRepository _repo;

        public InvoiceManager(IInvoiceRepository repo)
        {
            _repo = repo;
        }
        public Operation<InvoiceModel> CreateInvoice(InvoiceModel model)
        {
            return Operation.Create(() =>
            {
                if (model == null) throw new Exception("No Data Received");
                model.Validate().Throw();

                var newInvoice = _repo.CreateInvoice(model);
                return newInvoice;
            });
        }

        public Operation<InvoiceModel[]> GetInvoiceByAddressId(int addressId)
        {
            return Operation.Create(() =>
            {
                return _repo.GetInvoiceByAddressId(addressId);
            });
        }

        public Operation<InvoiceModel[]> GetInvoiceByCustomerId(int customerId)
        {
            return Operation.Create(() =>
             {
                 return _repo.GetInvoicesByCustomerId(customerId);
             });
        }

        public Operation<InvoiceModel[]> GetInvoiceByCustomerIdAndAddres(int customerId, int addressId)
        {    
            return Operation.Create(() =>
            {
                return _repo.GetInvoiceByCustomerIdAndAddress(customerId, addressId);
            });
        }

        public Operation<InvoiceModel[]> GetInvoiceByCustomerIdAndMonth(int customerId, int month)
        {   
            return Operation.Create(() =>
            {
                return _repo.GetInvoiceByCustomerIdAndMonth(customerId, month);
            });
        }

        public Operation<InvoiceModel[]> GetInvoiceByCustomerIdFilterAndMonth(int customerId, string filter, int month)
        {
            return Operation.Create(() =>
            {
                return _repo.GetInvoiceByCustomerIdFilterAndMonth(customerId, filter, month);
            });
        }
    }
}
