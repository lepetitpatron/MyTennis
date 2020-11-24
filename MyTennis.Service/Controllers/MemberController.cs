using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using MyTennis.BLL.Logic;
using MyTennis.Core.DTO;

namespace MyTennis.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberLogic logic;

        public MemberController()
        {
            this.logic = new MemberLogic();
        }

        [HttpGet]
        public List<MemberDTO> GetMembers()
        {
            return logic.GetAll();
        }

        [HttpGet("{id}")]
        public MemberDTO GetMember(int id)
        {
            return logic.FindById(id);
        }

        [HttpPut]
        public HttpResponseMessage UpdateMember([FromBody] MemberDTO member)
        {
            if (logic.Update(member))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage PostMember([FromBody] MemberDTO member)
        {
            if (logic.Create(member))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteMember(int id)
        {
            if (logic.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}