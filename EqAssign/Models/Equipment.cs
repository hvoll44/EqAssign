using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EqAssign.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ModelType ModelType { get; set; }

        [Required]
        [Display(Name = "Model Type")]
        public byte ModelTypeId { get; set; }

        [Required]
        [Display(Name = "Manufacture Date")]
        public DateTime? ManufactureDate { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        public DateTime? PurchaseDate { get; set; }

        [Required]
        [Range(1,20)]
        public int Stock { get; set; }

        public int Available { get; set; }

    }
}