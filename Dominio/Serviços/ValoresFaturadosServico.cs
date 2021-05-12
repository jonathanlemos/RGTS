using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class ValoresFaturadosServico : ServicoBase<ValoresFaturado>, IValoresFaturadosServico
    {
        private readonly IValoresFaturadosRepositorio valoresFaturadosRepositorio;

        public ValoresFaturadosServico(IValoresFaturadosRepositorio valoresFaturadosRepositorio) : base(valoresFaturadosRepositorio)
        {
            this.valoresFaturadosRepositorio = valoresFaturadosRepositorio;
        }

        public List<ValoresFaturado> GetFilter(int tipoInstrumento, int anoMesProcDe, int anoMesProcAte, int[] lucs, int[] marcas, DateTime vencimentoDe, DateTime vencimentoAte, bool? enviados)
        {
            return this.valoresFaturadosRepositorio.filter(tipoInstrumento, anoMesProcDe, anoMesProcAte, lucs, marcas, vencimentoDe, vencimentoAte, enviados);
        }
    }
}
