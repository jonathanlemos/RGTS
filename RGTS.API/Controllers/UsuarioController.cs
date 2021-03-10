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
    public class UsuarioController : ControllerBase
    {
        IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<Usuario> Get(int id)
        {
            try
            {
                return _usuarioServico.GetById(id);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            try
            {
                return Ok(_usuarioServico.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(NotificacaoPost), StatusCodes.Status200OK)]
        public ActionResult<NotificacaoPost> Post(Usuario usuario)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                _usuarioServico.CadastrarUsuario(usuario);                
                return notificacaoPost;
            }
            catch(Exception e)
            {
                notificacaoPost.Sucesso = false;
                notificacaoPost.Mensagem = "Erro ao salvar o usuário. Erro: " + e.Message;
                return notificacaoPost;
            }
        }

        [HttpPost("postUsuarios")]
        [ProducesResponseType(typeof(NotificacaoPost), StatusCodes.Status200OK)]
        public ActionResult<NotificacaoPost> postUsuarios(Usuario[] usuario)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                _usuarioServico.AtualizarUsuarios(usuario);
                return notificacaoPost;
            }
            catch (Exception e)
            {
                notificacaoPost.Sucesso = false;
                notificacaoPost.Mensagem = "Erro ao salvar o usuário. Erro: " + e.Message;
                return notificacaoPost;
            }
        }


    }
}
