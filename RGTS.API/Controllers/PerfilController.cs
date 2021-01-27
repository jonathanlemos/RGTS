using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
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
        IPerfilRepositorio _perfilRepositorio;

        public PerfilController(IPerfilRepositorio perfilRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
        }

        [HttpGet]
        public ActionResult<List<Perfil>> Get()
        {
            try
            {
                //return new List<Perfil>() { new Perfil() { Id = 1, Descricao = "Teste" } };
                return _perfilRepositorio.GetAll().ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<NotificacaoPost> Post(Perfil perfil)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                _perfilRepositorio.Add(perfil);
                return notificacaoPost;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
