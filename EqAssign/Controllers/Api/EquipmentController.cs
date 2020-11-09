using AutoMapper;
using System.Data.Entity;
using EqAssign.Dtos;
using EqAssign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EqAssign.Controllers.Api
{
   // [RoutePrefix("api/equipment")]
    public class EquipmentController : ApiController
    {
        private MyDBContext _context;
        public EquipmentController()
        {
            _context = new MyDBContext();
        }

        // GET /api/equipment
        public IEnumerable<EquipmentDto> GetEquipment(string query = null)
        {
            var equipmentQuery = _context.Equipment
                .Include(e => e.ModelType)
                .Where(e => e.Available > 0);


            if (!String.IsNullOrWhiteSpace(query))
                equipmentQuery = equipmentQuery.Where(e => e.Name.Contains(query));

            return equipmentQuery
                .ToList()
                .Select(Mapper.Map<Equipment, EquipmentDto>);
        }

        // GET /api/equipment/1
        public IHttpActionResult GetEquipments(int id)
        {
            var equipment = _context.Equipment.SingleOrDefault(e => e.Id == id);

            if (equipment == null)
                return NotFound();

            return Ok(Mapper.Map<Equipment, EquipmentDto>(equipment));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateEquipment(EquipmentDto equipmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var equipment = Mapper.Map<EquipmentDto, Equipment>(equipmentDto);
            _context.Equipment.Add(equipment);
            _context.SaveChanges();

            equipmentDto.Id = equipment.Id;

            return Created(new Uri(Request.RequestUri + "/" + equipment.Id), equipmentDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateEquipment(int id, EquipmentDto equipmentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var equipmentInDb = _context.Equipment.SingleOrDefault(e => e.Id == id);

            if (equipmentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(equipmentDto, equipmentInDb);

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteEquipment(int id)
        {
            var equipmentInDb = _context.Equipment.SingleOrDefault(e => e.Id == id);

            if (equipmentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Equipment.Remove(equipmentInDb);
            _context.SaveChanges();
        }
    }
}