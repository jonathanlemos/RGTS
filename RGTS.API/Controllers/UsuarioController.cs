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
    public class UsuarioController : ControllerBase
    {
        IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("usuario/Get/{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            try
            {
                //return Ok(_usuarioRepositorio.GetById(id));
                return _usuarioRepositorio.GetById(id);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        public ActionResult<NotificacaoPost> Post(Usuario usuario)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                _usuarioRepositorio.CadastrarNovoUsuario(usuario);
                
                notificacaoPost.Sucesso = true;
                notificacaoPost.Mensagem = "Salvo com sucesso.";
                return notificacaoPost;
            }
            catch(Exception e)
            {
                notificacaoPost.Sucesso = false;
                notificacaoPost.Mensagem = "Erro ao salvar o usuário. Erro: " + e.Message;
                return notificacaoPost;
            }
        }
    }
}
