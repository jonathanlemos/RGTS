using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;

namespace Dominio.Serviços
{
    public class ContratoUnidadeServico : ServicoBase<ContratoUnidade>, IContratoUnidadeServico
    {
        private readonly IContratoUnidadeRepositorio contratoUnidadeRepositorio;

        public ContratoUnidadeServico(IContratoUnidadeRepositorio contratoUnidadeRepositorio) : base(contratoUnidadeRepositorio)
        {
            this.contratoUnidadeRepositorio = contratoUnidadeRepositorio;
        }
    }
}
