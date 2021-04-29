using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Dominio.Autenticacao;
using System.Linq;

namespace Dominio.Servicos
{
    public class LoginPessoaServico : ServicoBase<LoginPessoa>, ILoginPessoaServico
    {
        

        public LoginPessoaServico(ILoginPessoaRepositorio loginRepositorio) : base(loginRepositorio)
        {

        }

        public string GerarToken(LoginPessoa login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AutenticacaoConfig.chave);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, login.PessoaId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidarLogin(LoginPessoa login)
        {
            try
            {
                bool ehValido = GetAll()
                   .Where(i => i.LoginAcesso == login.LoginAcesso
                   && i.Senha == login.Senha).Count() > 0 ? true : false;

                return ehValido;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
