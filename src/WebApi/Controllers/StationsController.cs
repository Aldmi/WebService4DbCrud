using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BL.Servises;
using DAL.Concrete;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApi.Model;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        private readonly IStationRepository _stationRepository;

        public StationsController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }



        // GET api/stations
        [HttpGet]
        public IEnumerable<StationModel> Get()
        {
            var stationsMoq = new List<StationModel>()
            {
                new StationModel {Id = 1, NameEng = "Station 1"},
                new StationModel {Id = 2, NameEng = "Station 2"}
            };

            var service = new StationService(_stationRepository);

            Log.Error("!!!!!!!!!!!!!!!!!!! gfgfg");

        

            var stations = service.GetStations(User);
            //MAP DAL.Station -> StationModel 

            return stationsMoq;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
