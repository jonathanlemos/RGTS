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
    public class ContratoLocacaoServico : ServicoBase<ContratoLocacao>, IContratoLocacaoServico
    {
        private readonly IContratoLocacaoRepositorio contratoLocacaoRepositorio;
        public ContratoLocacaoServico(IContratoLocacaoRepositorio contratoLocacaoRepositorio) : base(contratoLocacaoRepositorio)
        {
            this.contratoLocacaoRepositorio = contratoLocacaoRepositorio;
        }
    }
}
