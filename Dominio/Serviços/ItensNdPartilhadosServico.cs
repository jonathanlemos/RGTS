using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class ItensNdPartilhadosServico: ServicoBase<ItensNdPartilhado>, IItensNdPartilhadosServico
    {
        private readonly IItensNdPartilhadosRepositorio _itensNdPartilhadosRepositorio;

        public  ItensNdPartilhadosServico(IItensNdPartilhadosRepositorio itensNdPartilhadoRepoitorio) : base(itensNdPartilhadoRepoitorio)
        {
            this._itensNdPartilhadosRepositorio = itensNdPartilhadoRepoitorio;
        }
    }
}
