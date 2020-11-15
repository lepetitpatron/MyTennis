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

        [HttpPost]
        public HttpResponseMessage PostMember([FromBody] MemberDTO member)
        {
            if (logic.Create(member))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public string test()
        {
            return "ok";
        }
    }
}
