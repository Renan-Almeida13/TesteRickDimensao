using System;
using Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TesteRickDimensao.Controllers.Base;
using Core.ViewModels;
using Data.Context;

namespace RickLocalization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RickController : LocalizacaoRickControllerBase
    {
        private readonly IRickCore _core;

        public RickController(IRickCore core, IConfiguration configuration) : base(configuration)
        {
            _core = core;
        }

        internal override void CreateCoreConnections()
        {
            _core.CreateConnection(_Server);
        }

        [HttpGet]
        [Route("GetRick")]
        [AllowAnonymous]
        public IActionResult GetRick()
        {
            var ret = _core.GetRick();
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetRickById/{id:int}")]
        [AllowAnonymous]
        public IActionResult GetRickById(int id)
        {
            var ret = _core.GetRickById(id);
            return Ok(ret);
        }

        [HttpPost]
        [Route("PostRick")]
        [AllowAnonymous]
        public IActionResult PostRick([FromBody] RickViewModel rick)
        {
            try
            {
                object ret = _core.PostRick(rick);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar o Rick.");
            }
        }

        [HttpPut]
        [Route("UpdateRick")]
        [AllowAnonymous]
        public IActionResult UpdateRick([FromBody] RickViewModel rick)
        {
            try
            {
                object ret = _core.UpdateRick(rick);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível modificar o Rick.");
            }
        }

        [HttpDelete]
        [Route("DeleteRick")]
        [AllowAnonymous]
        public IActionResult DeleteRick(int id)
        {
            try
            {
                object ret = _core.DeleteRick(id);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível excluir o Rick.");
            }
        }
    }
}
