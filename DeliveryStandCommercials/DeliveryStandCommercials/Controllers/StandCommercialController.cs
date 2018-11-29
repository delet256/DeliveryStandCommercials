using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryStandCommercials.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryStandCommercials.Controllers
{
    [Route("api/StandCommercial")]
    public class StandCommercialController : Controller
    {


        /*
                // GET: api/<controller>
                [HttpGet]
                public IEnumerable<Commercial> Get()
                {
                    return new string[] { "value1", "value2" };
                }

                // GET api/<controller>/5
                [HttpGet("{id}")]
                public string Get(int id)
                {
                    return "value";
                }

                */

        /*
                // GET: api/<controller>
                [HttpGet]
                public IEnumerable<Commercial> Get()
                {
                    return new Commercial { CommercialName = "dddaaaa"};
                }

                // GET api/<controller>/5
                [HttpGet("{id}")]
                public Commercial Get(int idCommercial)
                {
                    using (var db = new StandCommercialContext())
                    {
                        var commercial = db.Commercials.FirstOrDefault(c => c.Id == idCommercial);

                        return commercial;
                    }
                }
                */



        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /*
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        */
        /*
        // GET api/<controller>/5
        [HttpGet("{idStand}")]
        public Commercial Get(int idStand)
        {


            return "value";
        }

        */



        [HttpPost]

        public void AddStandCommercialMapping([FromBody]StandCommercial standCommercial)
        {
            var temp = new StandCommercialRepository();
            temp.AddStandCommercial(standCommercial.CommercialId, standCommercial.StandId);

        }
        // POST api/<controller>

        [HttpPost]
        [Route("Commercial")]
        public void AddCommercial([FromBody]Commercial commercial)
        {
            var temp = new StandCommercialRepository();
            temp.AddCommercial(commercial);
        }


        [HttpPost]
        [Route("Stand")]
        public void AddStand([FromBody]Stand stand)
        {
            var temp = new StandCommercialRepository();
            temp.AddStand(stand);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{idCommercial}")]
        [Route("Commercial")]
        public void DeleteCommercial(int idCommercial)
        {
            var temp = new StandCommercialRepository();
            temp.DeleteCommercial(idCommercial);
        }

        [HttpDelete("{idCommercial}/{idStand}")]
        public void DeleteStandCommercial(int idCommercial, int idStand)
        {
            var temp = new StandCommercialRepository();
            temp.DeleteStandCommercial(idCommercial, idStand);
        }
    }
}
