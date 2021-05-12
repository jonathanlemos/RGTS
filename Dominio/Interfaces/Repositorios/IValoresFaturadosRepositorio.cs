using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Repositorios
{
    public interface IValoresFaturadosRepositorio : IRepositorioBase<ValoresFaturado>
    {
        List<ValoresFaturado> filter(int tipoInstrumento, int anoMesProcDe, int anoMesProcAte, int[] lucs, int[] marcas, DateTime vencimentoDe, DateTime vencimentoAte, bool? enviados);
    }
}