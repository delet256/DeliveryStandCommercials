using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryStandCommercials.Models
{
    public class Commercial
    {
        public int Id { get; set; }
        public string CommercialName { get; set; }
        public DateTime DateUpload { get; set; }
        public DateTime DateDelete { get; set; }
        public string URLCommercial { get; set; }
        public string Comment { get; set; }
        public List<StandCommercial> StandCommercials { get; set; }
        public Commercial()
        {
            StandCommercials = new List<StandCommercial>();
        }
    }
}
