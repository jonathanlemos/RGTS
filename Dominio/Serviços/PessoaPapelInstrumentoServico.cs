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
    public class PessoaPapelInstrumentoServico : ServicoBase<PessoaPapelInstrumento>, IPessoaPapelInstrumentoServico
    {
        private readonly IPessoaPapelInstrumentoRepositorio pessoaPapelInstrumentoRepositorio;

        public PessoaPapelInstrumentoServico(IPessoaPapelInstrumentoRepositorio _pessoaPapelInstrumentoRepositorio) : base(_pessoaPapelInstrumentoRepositorio)
        {
            this.pessoaPapelInstrumentoRepositorio = _pessoaPapelInstrumentoRepositorio;
        }
    }
}