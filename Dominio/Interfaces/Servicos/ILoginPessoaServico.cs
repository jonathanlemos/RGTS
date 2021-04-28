using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces.Servicos
{
    public interface ILoginPessoaServico : IServicoBase<LoginPessoa>
    {
        public bool ValidarLogin(LoginPessoa login);

        public string GerarToken(LoginPessoa login);
    }
}
