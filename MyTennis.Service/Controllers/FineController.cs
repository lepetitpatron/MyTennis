using Microsoft.AspNetCore.Mvc;
using MyTennis.BLL.Logic;
using MyTennis.Core.DTO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace MyTennis.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FineController : ControllerBase
    {
        private readonly FineLogic logic;

        public FineController()
        {
            logic = new FineLogic();
        }

        [HttpGet]
        public List<FineDTO> GetFines()
        {
            return logic.GetAll();
        }

        [HttpGet("{id}")]
        public FineDTO GetFine(int id)
        {
            return logic.FindById(id);
        }

        [HttpPut]
        public HttpResponseMessage UpdateFine([FromBody] FineDTO fine)
        {
            if (logic.Update(fine))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage PostRole([FromBody] FineDTO fine)
        {
            if (logic.Create(fine))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
