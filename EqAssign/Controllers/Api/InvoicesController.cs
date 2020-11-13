using AutoMapper;
using EqAssign.Dtos;
using EqAssign.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace EqAssign.Controllers.Api
{
    public class InvoicesController : ApiController
    {
        private MyDBContext _context;
        public InvoicesController()
        {
            _context = new MyDBContext();
        }


        // GET /api/invoices
        public IEnumerable<InvoiceDto> GetInvoices(string query = null)
        {
            return _context.Invoices
                .Include(i => i.Customer).Include(i => i.Equipment)
                .ToList()
                .Select(Mapper.Map<Invoice, InvoiceDto>);
        }


        // GET /api/invoices/1
        public IHttpActionResult GetInvoice(int id)
        {
            var invoice = _context.Invoices.SingleOrDefault(c => c.Id == id);

            if (invoice == null)
                return NotFound();

            return Ok(Mapper.Map<Invoice, InvoiceDto>(invoice));
        }


        // POST /api/invoices
        [HttpPost]
        public IHttpActionResult CreateInvoice(InvoiceDto invoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var invoice = Mapper.Map<InvoiceDto, Invoice>(invoiceDto);
            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            invoiceDto.Id = invoice.Id;

            return Created(new Uri(Request.RequestUri + "/" + invoice.Id), invoiceDto);
        }

        // PUT /api/invoices/1
        [HttpPut]
        public void UpdateCustomer(int id, InvoiceDto invoiceDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var invoiceInDb = _context.Invoices.SingleOrDefault(i => i.Id == id);

            if (invoiceInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            invoiceInDb.DateReturned = DateTime.Now;

            Mapper.Map(invoiceDto, invoiceInDb);

            var equipment = _context.Equipment.Single(
                e => e.Id == invoiceInDb.EquipmentId);

            equipment.Available++;

            _context.SaveChanges();


        }

    }
}
