using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class CidadeServico : ServicoBase<Cidade>, ICidadeServico
    {
        private readonly ICidadeRepositorio cidadeRepositorio;

        public CidadeServico(ICidadeRepositorio _cidadeRepositorio) : base(_cidadeRepositorio)
        {
            this.cidadeRepositorio = _cidadeRepositorio;
        }
    }
}
