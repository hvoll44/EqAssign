using AutoMapper;
using EqAssign.Dtos;
using EqAssign.DTOs;
using EqAssign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
