using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
        public Perfil[] Get()
        {
            try
            {
                return _perfilServico.GetAll().ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
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
