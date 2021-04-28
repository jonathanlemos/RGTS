using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using Microsoft.AspNetCore.Authorization;
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
    public class LoginPessoaController : ControllerBase
    {
        ILoginPessoaServico loginServico;

        public LoginPessoaController(ILoginPessoaServico loginServico)
        {
            this.loginServico = loginServico;
        }

        [HttpPost]
        [Route("ValidarAcesso")]
        [AllowAnonymous]
        //[Authorize("")]
        public async Task<ActionResult<NotificacaoPost>> ValidarAcesso([FromBody] LoginPessoa login)
        {
            NotificacaoPost notificacaoPost = new NotificacaoPost();
            try
            {
                bool ehValido = loginServico.ValidarLogin(login);

                if (!ehValido)
                {
                    notificacaoPost.Sucesso = false;
                    notificacaoPost.Mensagem = "Usuário ou senha inválidos";
                    return notificacaoPost;
                }

                var token = loginServico.GerarToken(login);
                notificacaoPost.Token = token;
                login.Senha = "";

                return notificacaoPost;
            }
            catch(Exception e)
            {
                notificacaoPost.Sucesso = false;
                notificacaoPost.Mensagem = e.Message;
                return notificacaoPost;
            }
        }

        //public string UsuarioAutenticado() => string.Format("Usúario autenticado: ");
    }
}
