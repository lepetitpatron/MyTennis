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
    public class MemberRoleController : Controller
    {
        private readonly MemberRoleLogic logic;

        public MemberRoleController()
        {
            this.logic = new MemberRoleLogic();
        }

        [HttpGet("{role}")]
        public List<MemberRoleDTO> GetAllMembers(int role)
        {
            return logic.GetAllMembers(role);
        }

        [HttpPut("{member}")]
        public List<MemberRoleDTO> GetAllRoles(int member)
        {
            return logic.GetAllRoles(member);
        }

        [HttpPost]
        public HttpResponseMessage PostMember([FromBody] MemberRoleDTO memberRole)
        {
            if (logic.Create(memberRole))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete("{memberId}/{roleId}")]
        public HttpResponseMessage DeleteMember(int memberId, int roleId)
        {
            if (logic.Delete(memberId, roleId))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}