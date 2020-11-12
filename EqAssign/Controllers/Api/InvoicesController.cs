using AutoMapper;
using EqAssign.Dtos;
using EqAssign.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public IEnumerable<InvoiceDto> GetInvoices(string query = null)
        {
            return _context.Invoices
                .Include(i => i.Customer).Include(i => i.Equipment)
                .ToList()
                .Select(Mapper.Map<Invoice, InvoiceDto>);
        }

    }
}
