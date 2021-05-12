using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class LucServico : ServicoBase<Luc>, ILucServico
    {
        private readonly ILucRepositorio lucRepositorio;

        public LucServico(ILucRepositorio lucRepositorio) : base(lucRepositorio)
        {
            this.lucRepositorio = lucRepositorio;
        }
    }
}
