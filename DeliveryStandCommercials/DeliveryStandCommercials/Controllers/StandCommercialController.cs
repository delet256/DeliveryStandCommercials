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




        //  Commercial controller

     
        /// <summary>
        /// Get list of commercial
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Commercial")]
        public IEnumerable<Commercial> GetListAllCommercials()
        {
            var repository = new StandCommercialRepository();
            return repository.GetAllCommercials();
        }

        /// <summary>
        /// Get the commercial
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Commercial/{id}")]
        public Commercial GetCommercial(int id)
        {
            var repository = new StandCommercialRepository();
            return repository.GetCommercial(id);
        }



        /// <summary>
        /// To get list commercials of particular stand
        /// </summary>
        /// <param name="standId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CurrentStand/{standId}")]
        public IEnumerable<Commercial> GetListCommercialCurrentStand(int standId)
        {
            var repository = new StandCommercialRepository();
            return repository.GetCommercialCurrentStand(standId);
        }


/*        
        [HttpPost]
        [Route("Commercial/{standId}")]
        public int AddCommercialCurrentStand([FromBody]StandCommercial standCommercial)
        {
            var temp = new StandCommercialRepository();
            return temp.AddCommercialCurrentStand(standCommercial.CommercialId, standCommercial.StandId);

        }
        */
        

        /// <summary>
        /// To add the commercial
        /// </summary>
        /// <param name="commercial"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Commercial")]
        public int AddCommercial([FromBody]Commercial commercial)
        {
            var repository = new StandCommercialRepository();
            return repository.AddCommercial(commercial);
        }

        /// <summary>
        /// To update the commercial
        /// </summary>
        /// <param name="commercial"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Commercial")]
        public int UpdateCommercial([FromBody]Commercial commercial)
        {
            var repository = new StandCommercialRepository();
            return repository.UpdateCommercial(commercial);
        }

        /// <summary>
        /// To delete the commercial
        /// </summary>
        /// <param name="idCommercial"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Commercial/{idCommercial}")]
        public int DeleteCommercial(int idCommercial)
        {
            var repository = new StandCommercialRepository();
            return repository.DeleteCommercial(idCommercial);
        }




        // Stands controller

        /// <summary>
        /// Get list of stands
        /// </summary>
        /// <param name="stand"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Stand")]
        public IEnumerable<Stand> GetListAllStands()
        {
            var repository = new StandCommercialRepository();
            return repository.GetAllStands();
        }

        /// <summary>
        /// Get the stand
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Stand/{id}")]
        public Stand GetStand(int id)
        {
            var repository = new StandCommercialRepository();
            return repository.GetStand(id);
        }

        /// <summary>
        /// To add the stand
        /// </summary>
        /// <param name="stand"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Stand")]
        public int AddStand([FromBody]Stand stand)
        {
            var repository = new StandCommercialRepository();
            return repository.AddStand(stand);
        }

        /// <summary>
        /// To update the stand
        /// </summary>
        /// <param name="stand"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Stand")]
        public int UpdateStand([FromBody]Stand stand)
        {
            var repository = new StandCommercialRepository();
            return repository.UpdateStand(stand);
        }

        /// <summary>
        /// To delete the stand
        /// </summary>
        /// <param name="idStand"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Stand/{idStand}")]
        public int DeleteStand(int idStand)
        {
            var repository = new StandCommercialRepository();
            return repository.DeleteStand(idStand);
        }




        //Controller for mapping commercial and stand


        [HttpPost]
        public void AddStandCommercial([FromBody] int[] commercialIdAndStandId)
        {
            var repository = new StandCommercialRepository();
            //  repository.AddStandCommercial(commercialId,standId);
            repository.AddStandCommercial(commercialIdAndStandId[0], commercialIdAndStandId[1]);
        }

               

        [HttpDelete("{idCommercial}/{idStand}")]
        public void DeleteStandCommercial(int idCommercial, int idStand)
        {
            var temp = new StandCommercialRepository();
            temp.DeleteStandCommercial(idCommercial, idStand);
        }
    }
}
