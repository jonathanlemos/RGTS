using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class ContratoLocacaoServico : ServicoBase<ContratoLocacao>, IContratoLocacaoServico
    {
        private readonly IContratoLocacaoRepositorio contratoLocacaoRepositorio;

        public ContratoLocacaoServico(IContratoLocacaoRepositorio contratoLocacaoRepositorio) : base(contratoLocacaoRepositorio)
        {
            this.contratoLocacaoRepositorio = contratoLocacaoRepositorio;
        }

        public ContratoLocacao GetByIdInstrumento(int idInstrumento)
        {
            return this.contratoLocacaoRepositorio.GetByIdInstrumento(idInstrumento);
        }
    }
}
