using Microsoft.AspNetCore.Mvc;
using MyTennis.BLL;
using MyTennis.Core;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace MyTennis.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleLogic logic;

        public RoleController()
        {
            this.logic = new RoleLogic();
        }

        [HttpGet]
        public List<RoleDTO> GetRoles()
        {
            return logic.GetAll();
        }

        [HttpGet("{id}")]
        public RoleDTO GetRole(int id)
        {
            return logic.FindById(id);
        }

        [HttpPut]
        public HttpResponseMessage UpdateRole([FromBody] RoleDTO role)
        {
            if (logic.Update(role))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public HttpResponseMessage PostRole([FromBody] RoleDTO role)
        {
            if (logic.Create(role))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}