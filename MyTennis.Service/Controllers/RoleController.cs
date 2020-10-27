using Microsoft.AspNetCore.Mvc;
using MyTennis.BLL;
using MyTennis.Core;
using System.Collections.Generic;

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