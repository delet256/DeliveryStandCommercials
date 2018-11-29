using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryStandCommercials.Models
{
    public class StandCommercial
    {
        public int CommercialId { get; set; }
        public Commercial Commercial { get; set; }
        public int StandId { get; set; }
        public Stand Stand { get; set; }
    }
}
