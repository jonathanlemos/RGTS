using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos
{
    public class PessoaServico : ServicoBase<Pessoa>, IPessoaServico
    {
        private readonly IPessoaRepositorio _PessoaRepositorio;

        public PessoaServico(IPessoaRepositorio PessoaRepositorio) : base(PessoaRepositorio)
        {
            _PessoaRepositorio = PessoaRepositorio;
        }

        public void CadastrarPessoa(Pessoa Pessoa)
        {
            _PessoaRepositorio.CadastrarNovoUsuario(Pessoa);
        }

        public void AtualizarPessoas(Pessoa[] Pessoas)
        {
            for (var i=0; i< Pessoas.Length; i++)
            {
                _PessoaRepositorio.Update(Pessoas[i]);
            }
        }
    }
}
