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
    public class ResultController : ControllerBase
    {
        private readonly ResultLogic logic;

        public ResultController()
        {
            logic = new ResultLogic();
        }

        [HttpGet]
        public List<ResultDTO> GetResults()
        {
            return logic.GetAll();
        }

        [HttpGet("{id}")]
        public ResultDTO GetResult(int id)
        {
            return logic.FindById(id);
        }

        [HttpPut]
        public HttpResponseMessage UpdateResult([FromBody] ResultDTO result)
        {
            if (logic.Update(result))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage PostResult([FromBody] ResultDTO result)
        {
            if (logic.Create(result))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteResult (int id)
        {
            if (logic.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}