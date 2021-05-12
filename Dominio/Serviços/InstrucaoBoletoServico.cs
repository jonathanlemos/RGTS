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
    public class InstrucaoBoletoServico : ServicoBase<InstrucaoBoleto>, IInstrucaoBoletoServico
    {
        private readonly IInstrucaoBoletoRepositorio _instrucaoBoletoRepositorio;

        public InstrucaoBoletoServico(IInstrucaoBoletoRepositorio instrucaoBoletoRepositorio) : base(instrucaoBoletoRepositorio)
        {
            this._instrucaoBoletoRepositorio = instrucaoBoletoRepositorio;
        }
    }
}
