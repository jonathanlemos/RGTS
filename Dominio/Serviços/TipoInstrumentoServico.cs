using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class TipoInstrumentoServico : ServicoBase<TipoInstrumento>, ITipoInstrumentoServico
    {
        private readonly ITipoInstrumentoRepositorio tipoInstrumentoRepositorio;

        public TipoInstrumentoServico(ITipoInstrumentoRepositorio tipoInstrumentoRepositorio) : base(tipoInstrumentoRepositorio)
        {
            this.tipoInstrumentoRepositorio = tipoInstrumentoRepositorio;
        }
    }
}
