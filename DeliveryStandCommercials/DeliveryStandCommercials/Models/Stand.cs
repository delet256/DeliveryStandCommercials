using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryStandCommercials.Models
{
    public class Stand
    {
        public int Id { get; set; }
        public string StandName { get; set; }
        public List<StandCommercial> StandCommercials { get; set; }
        public Stand()
        {
            StandCommercials = new List<StandCommercial>();
        }
    }
}
