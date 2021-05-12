using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class ContratoLucsServico : ServicoBase<ContratoLuc>, IContratoLucsServico
    {
        private readonly IContratoLucsRepositorio contratoLucsRepositorio;

        public ContratoLucsServico(IContratoLucsRepositorio contratoLucsRepositorio) : base(contratoLucsRepositorio)
        {
            this.contratoLucsRepositorio = contratoLucsRepositorio;
        }

        public ContratoLuc GetInstrumentoIdByLucId(int idLuc)
        {
            return this.contratoLucsRepositorio.GetInstrumentoIdByLucId(idLuc);
        }

        public ContratoLuc GetLucIdByInstrumentoId(int idInstrumento)
        {
            return this.contratoLucsRepositorio.GetLucIdByInstrumentoId(idInstrumento);
        }
    }
}
