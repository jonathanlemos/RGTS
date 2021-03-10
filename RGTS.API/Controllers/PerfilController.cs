using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        IPerfilServico _perfilServico;

        public PerfilController(IPerfilServico perfilServico)
        {
            _perfilServico = perfilServico;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Perfil>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Perfil>> Get()
        {
            try
            {
                return Ok( _perfilServico.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(NotificacaoPost), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<NotificacaoPost> Post(Perfil perfil)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                _perfilServico.Add(perfil);
                return notificacaoPost;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
