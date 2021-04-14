using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Servicos
{
    public interface IPessoaServico : IServicoBase<Pessoa>
    {
        public void CadastrarPessoa(Pessoa Pessoa);

        public void AtualizarPessoas(Pessoa[] Pessoa);
    }
}
