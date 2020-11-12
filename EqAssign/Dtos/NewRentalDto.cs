using System;
using System.Collections.Generic;


namespace EqAssign.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }

        public List<int> EquipmentIds { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}