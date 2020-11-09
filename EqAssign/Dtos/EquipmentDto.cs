using EqAssign.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EqAssign.Dtos
{
    public class EquipmentDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        //public ModelType ModelType { get; set; }

        [Required]
        public byte ModelTypeId { get; set; }

        public ModelsDto ModelType { get; set; }

        [Required]
        public DateTime? ManufactureDate { get; set; }
        
        [Required]
        public DateTime? PurchaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int Stock { get; set; }

    }
}