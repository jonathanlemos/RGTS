using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Servicos
{
    public interface IValoresFaturadosServico : IServicoBase<ValoresFaturado>
    {
        List<ValoresFaturado> GetFilter(int tipoInstrumento, int anoMesProcDe, int anoMesProcAte, int[] lucs, int[] marcas, DateTime vencimentoDe, DateTime vencimentoAte, bool? enviados);
    }
}
