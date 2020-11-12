using EqAssign.DTOs;
using System;

namespace EqAssign.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public int EquipmentId { get; set; }
        public EquipmentDto Equipment { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}