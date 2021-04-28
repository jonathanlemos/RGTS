using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RGTS.API.Models;
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
        IPessoaServico _pessoaServico;

        public UsuarioController(IPessoaServico usuarioServico)
        {
            _pessoaServico = usuarioServico;
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(int id)
        {
            try
            {
                return _pessoaServico.GetById(id);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet]
        [Authorize]
        public Pessoa[] Get()
        {
            try
            {
                var _pessoas= _pessoaServico.GetAll().ToArray();
                return _pessoas;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [Authorize]
        public ActionResult<NotificacaoPost> Post(CadastroDeUsuario Usuario)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                Pessoa pessoa = new Pessoa();
                pessoa.EstadoId = Usuario.Estado.Id;
                pessoa.CidadeId = Usuario.Cidade.Id;
                pessoa.Nome = Usuario.NomeCompleto;
                pessoa.PrimeiroNome = Usuario.PrimeiroNome;
                pessoa.Senha = Usuario.Senha;
                pessoa.SexoId = Usuario.Sexo.Id;
                pessoa.Email = Usuario.Email;

                _pessoaServico.CadastrarPessoa(pessoa);                
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
        [Authorize]
        public ActionResult<NotificacaoPost> postUsuarios(Pessoa[] Pessoa)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                _pessoaServico.AtualizarPessoas(Pessoa);
                return notificacaoPost;
            }
            catch (Exception e)
            {
                notificacaoPost.Sucesso = false;
                notificacaoPost.Mensagem = "Erro ao salvar o usuário. Erro: " + e.Message;
                return notificacaoPost;
            }
        }

        [Route("putUsuarios")]
        [Authorize]
        public ActionResult<NotificacaoPost> putUsuarios(Pessoa[] Pessoa)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                _pessoaServico.AtualizarPessoas(Pessoa);
                notificacaoPost.Mensagem = "Usuários editados com sucesso.";
                return notificacaoPost;
            }
            catch (Exception e)
            {
                notificacaoPost.Sucesso = false;
                notificacaoPost.Sucesso = false;
                notificacaoPost.Mensagem = "Erro ao editar os usuário. Erro: " + e.Message;
                return notificacaoPost;
            }
        }

    }
}
