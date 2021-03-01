using System;
using Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TesteRickDimensao.Controllers.Base;
using Core.ViewModels;

namespace TesteRickDimensao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversoController : LocalizacaoRickControllerBase
    {
        private readonly IUniversoCore _core;

        public UniversoController(IUniversoCore core, IConfiguration configuration) : base(configuration)
        {
            _core = core;
        }

        internal override void CreateCoreConnections()
        {
            _core.CreateConnection(_Server);
        }

        [HttpGet]
        [Route("GetUniverso")]
        [AllowAnonymous]
        public IActionResult GetDimensao()
        {
            var ret = _core.GetUniverso();
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetUniversoById/{id:int}")]
        [AllowAnonymous]
        public IActionResult GetUniversoById(int id)
        {
            var ret = _core.GetUniversoById(id);
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetHistoricoUniversoRick/{id:int}")]
        [AllowAnonymous]
        public IActionResult GetHistoricoUniversoRick(int id)
        {
            var ret = _core.GetHistoricoUniversoRick(id);
            return Ok(ret);
        }

        [HttpPost]
        [Route("PostUniverso")]
        [AllowAnonymous]
        public IActionResult PostUniverso([FromBody] UniversoViewModel universo)
        {
            try
            {
                object ret = _core.PostUniverso(universo);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar o universo.");
            }
        }

        [HttpPut]
        [Route("UpdateUniverso")]
        [AllowAnonymous]
        public IActionResult UpdateUniverso([FromBody] UniversoViewModel universo)
        {
            try
            {
                object ret = _core.UpdateUniverso(universo);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível alterar o universo.");
            }
        }

        [HttpDelete]
        [Route("DeleteUniverso")]
        [AllowAnonymous]
        public IActionResult DeleteUniverso(int id)
        {
            try
            {
                object ret = _core.DeleteUniverso(id);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível excluir o universo.");
            }
        }
    }
}
