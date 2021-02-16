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
    public class UsuarioController : ControllerBase
    {
        IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpGet("{id}")]
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
        public Usuario[] Get()
        {
            try
            {
                return _usuarioServico.GetAll().ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }

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

        [Route("postUsuarios")]
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
