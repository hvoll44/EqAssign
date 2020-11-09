using EqAssign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EqAssign.ViewModels
{
    public class EquipmentFormViewModel
    {
        public IEnumerable<ModelType> Models { get; set; }
        public Equipment Equipment { get; set; }
    }
}