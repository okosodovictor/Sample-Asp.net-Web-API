using BEAssignment.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BEAssignment.Api.Controllers
{
    [RoutePrefix("api/v1.0/customers")]
    [Authorize]
    public class CustomerController : ApiController
    {
        private IInvoiceManager _invoiceManager;

        public CustomerController(IInvoiceManager invoiceManager)
        {
            _invoiceManager = invoiceManager;
        }

        [HttpGet, Route("{customerId}/addresses/{addressId}/invoices")]
        public IHttpActionResult GetInvoices(int customerId, int addressId)
        {
            if (customerId <= 0 || addressId <= 0)
            {
                return BadRequest("Invalid passed Parameter");
            }
            var invoices = _invoiceManager.GetInvoiceByCustomerIdAndAddres(customerId, addressId);
            if (invoices == null)
            {
                return NotFound();
            }
            if(invoices.Succeeded)
            {
                return Ok(invoices.Result);
            }
            else
            {
                return InternalServerError(invoices.GetException());
            }
        }
    }
}
