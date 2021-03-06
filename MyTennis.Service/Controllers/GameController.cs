﻿using Microsoft.AspNetCore.Mvc;
using MyTennis.BLL.Logic;
using MyTennis.Core.DTO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace MyTennis.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameLogic logic;

        public GameController()
        {
            logic = new GameLogic();
        }

        [HttpGet]
        public List<GameDTO> GetGames()
        {
            return logic.GetAll();
        }

        [HttpGet("{id}")]
        public GameDTO GetGame(int id)
        {
            return logic.FindById(id);
        }

        [HttpPut]
        public HttpResponseMessage UpdateGame([FromBody] GameDTO game)
        {
            if (logic.Update(game))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage PostGame([FromBody] GameDTO game)
        {
            if (logic.Create(game))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteGame(int id)
        {
            if (logic.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
