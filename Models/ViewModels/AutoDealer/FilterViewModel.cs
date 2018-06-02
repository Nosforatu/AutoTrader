using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrader.Models.ViewModels.AutoDealer
{
    public class FilterViewModel
    {
        // Search Bar for Make, Model
        public string SearchCriteria { get; set; }

        // Price range braket
        public double PriceMinimum { get; set; }
        public double PriceMaximum { get; set; }
        public List<SelectListItem> PriceRange { get; set; }

        // 2L engin capacity
        public bool EnginCapacity { get; set; }

        // Celinder Variants
        public int CelinderVariant { get; set; }
        public List<SelectListItem> CelinderOptions { get; set; }

        // Singil Celinder Variant
        public double SingularCelinderCapacity { get; set; }

    }
}
