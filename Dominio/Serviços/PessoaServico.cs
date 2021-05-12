using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class PessoaServico: ServicoBase<Pessoa>, IPessoaServico
    {
        private readonly IPessoaRepositorio pessoaRepositorio;

        public PessoaServico(IPessoaRepositorio repositorio) : base(repositorio)
        {
            this.pessoaRepositorio = repositorio;
        }
    }
}
