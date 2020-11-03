using Microsoft.AspNetCore.Mvc;
using MyTennis.BLL;
using MyTennis.Core.DTO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace MyTennis.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly LeagueLogic logic;

        public LeagueController()
        {
            this.logic = new LeagueLogic();
        }

        [HttpGet]
        public List<LeagueDTO> GetLeagues()
        {
            return logic.GetAll();
        }

        [HttpGet("{id}")]
        public LeagueDTO GetLeague(int id)
        {
            return logic.FindById(id);
        }

        [HttpPut]
        public HttpResponseMessage UpdateRole([FromBody] LeagueDTO role)
        {
            if (logic.Update(role))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public HttpResponseMessage PostRole([FromBody] LeagueDTO role)
        {
            if (logic.Create(role))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteRole(int id)
        {
            if (logic.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
