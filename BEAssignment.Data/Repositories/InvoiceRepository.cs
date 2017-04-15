using BEAssignment.Core.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEAssignment.Core.Business;
using BEAssignment.Data.Entities;

namespace BEAssignment.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private DbContext _context;

        public InvoiceRepository(DbContext context)
        {
            _context = context;
        }

        public InvoiceModel CreateInvoice(InvoiceModel model)
        {
            var invoice = new Invoice();

            invoice.Assign(model);

            _context.Set<Invoice>().Add(invoice);
            _context.SaveChanges();

            model.Assign(invoice);
            return model;
        }

        public InvoiceModel[] GetInvoiceByAddressId(int addressId)
        {
            //Create the Query
            var query = from invoice in _context.Set<Invoice>()
                        where invoice.AddressId == addressId
                        select invoice;
            //Execute the Query
            var invoices = query.ToArray();

            //Return Invoices
            return invoices.Select(i => new InvoiceModel().Assign(i)).ToArray();
        }

        public InvoiceModel[] GetInvoiceByCustomerIdAndAddress(int customerId, int addressId)
        {
            //Create the Query
            var query = from invoice in _context.Set<Invoice>()
                        where invoice.Address.CustomerID == customerId
                        where invoice.AddressId == addressId
                        select invoice;

            //Execute the Query
            var invoices = query.ToArray();

            //Return Invoices
            return invoices.Select(i => new InvoiceModel().Assign(i)).ToArray();
        }

        public InvoiceModel[] GetInvoiceByCustomerIdAndMonth(int customerId, int month)
        {
            //Create the Query
            var query = from invoice in _context.Set<Invoice>()
                        where invoice.Address.CustomerID == customerId
                        where invoice.InvoiceDate.Value.Month == month
                        select invoice;
            //Execute the Query
            var invoices = query.ToArray();

            //Return Invoices
            return invoices.Select(i => new InvoiceModel().Assign(i)).ToArray();
        }

        public InvoiceModel[] GetInvoiceByCustomerIdFilterAndMonth(int customerId, string filter, int month)
        {
            //Create the Query
            var query = from invoice in _context.Set<Invoice>()
                        where invoice.Address.CustomerID == customerId
                        where invoice.Address.AddressName == filter
                        where invoice.InvoiceDate.Value.Month == month
                        select invoice;
            //Execute the Query
            var invoices = query.ToArray();

            //Return Invoices
            return invoices.Select(i => new InvoiceModel().Assign(i)).ToArray();
        }

        public InvoiceModel[] GetInvoicesByCustomerId(int customerId)
        {
            //var invoices = _context.Set<Invoice>().Where(i => i.Address.CustomerID == customerId).ToList();

            //var invoices2 = _context.Set<Address>().Where(i => i.CustomerID == customerId).SelectMany(a => a.Invoices).ToList();

            //var invoices3 = _context.Set<Customer>().Where(c => c.CustomerId == customerId).SelectMany(c => c.Addresses).SelectMany(a => a.Invoices).ToList();


            //Create the Query
            var query = from invoice in _context.Set<Invoice>()
                        where invoice.Address.CustomerID == customerId
                        select invoice;

            //Execute the Query
            var invoices = query.ToArray();

            //Return Invoices
            return invoices.Select(i => new InvoiceModel().Assign(i)).ToArray();
        }
    }
}
