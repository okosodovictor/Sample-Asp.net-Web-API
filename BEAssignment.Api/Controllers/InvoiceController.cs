using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BEAssignment.Core.Business;
using BEAssignment.Core.Interfaces.Managers;

namespace BEAssignment.Api.Controllers
{
    [RoutePrefix("api/v1.0/invoices")]
    [Authorize]
    public class InvoiceController : ApiController
    {
        private IInvoiceManager _manager;
        public InvoiceController(IInvoiceManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateInvoice([FromBody] InvoiceModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid passed data");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var operation = _manager.CreateInvoice(model);
                if (operation.Succeeded)
                {
                    return Created<InvoiceModel>(Request.RequestUri + "/" + operation.Result.InvoiceId.ToString(), operation.Result);
                    // return Ok("");
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetInvoiceByCustomerID(int customerId, string filter, int month = 0)
        {
            if (customerId <= 0) return BadRequest("Invalid passed Customer Id");

            Operation<InvoiceModel[]> getInvoices = new Operation<InvoiceModel[]>();

            if (month > 0 && customerId >= 0)
            {
                getInvoices = _manager.GetInvoiceByCustomerIdAndMonth(customerId, month);
            }
             else if (customerId >= 0 && month > 0 && filter!=null)
            {
                getInvoices = _manager.GetInvoiceByCustomerIdFilterAndMonth(customerId, filter, month);
            }
            else 
            {
                getInvoices = _manager.GetInvoiceByCustomerId(customerId);
            }


            if (getInvoices.Succeeded)
            {
                return Ok(getInvoices.Result);
            }
            else
            {
                return InternalServerError(getInvoices.GetException());
            }
        }
       // public  IHttpActionResult 
    }
}
