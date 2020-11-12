using AutoMapper;
using EqAssign.Dtos;
using EqAssign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EqAssign.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private MyDBContext _context;
        public NewRentalsController()
        {
            _context = new MyDBContext();
        }


        // GET /api/rentals
        public IEnumerable<NewRentalDto> GetRentals()
        {
            return _context.Rentals.ToList().Select(Mapper.Map<Rental, NewRentalDto>);
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var equipments = _context.Equipment.Where(
                e => newRental.EquipmentIds.Contains(e.Id)).ToList();

            foreach (var equipment in equipments)
            {
                if (equipment.Available == 0)
                    return BadRequest("Equipment not available.");

                equipment.Available--;

                var rental = new Rental
                {
                    Customer = customer,
                    Equipment = equipment,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);


                var invoice = new Invoice
                {
                    CustomerId = customer.Id,
                    EquipmentId = equipment.Id,
                    DateRented = DateTime.Now
                };

                _context.Invoices.Add(invoice);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
