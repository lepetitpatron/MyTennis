using Microsoft.AspNetCore.Mvc;

namespace MyTennis.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpGet]
        public void GetRoles()
        { }

        [HttpPut("{id}")]
        public void PutRole(int id)
        { }

        [HttpPost]
        public void PostProduct()
        { }

        private bool RoleExists()
        {
            return false;
        }
    }
}