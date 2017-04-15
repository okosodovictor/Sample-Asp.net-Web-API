using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BEAssignment.Core.Business;
using BEAssignment.Core.Interfaces.Managers;

namespace BEAssignment.Api.Controllers
{
    [RoutePrefix("api/v1.0/addresses")]
    [Authorize]
    public class AddressController : ApiController
    {
        private IInvoiceManager _manager;

        public AddressController(IInvoiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet, Route("{addressId}/invoices")]
        public IHttpActionResult GetInvoicesByAddressId(int addressId)
        {
            if (addressId <= 0) return BadRequest("Invalid passed address Id");

            Operation<InvoiceModel[]> Invoices = new Operation<InvoiceModel[]>();

            Invoices = _manager.GetInvoiceByAddressId(addressId);
            if (Invoices == null)
            {
                return NotFound();
            }
            if (Invoices.Succeeded)
            {
                return Ok(Invoices.Result);
            }
            else
            {
                return InternalServerError(Invoices.GetException());
            }
        }
    }
}
