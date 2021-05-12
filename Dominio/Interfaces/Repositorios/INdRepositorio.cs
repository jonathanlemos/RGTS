using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Repositorios
{
    public interface INdRepositorio : IRepositorioBase<Nd>
    {
        List<Nd> filter(int tipoInstrumento, int[] lucs, int[] marcas, DateTime vencimentoDe, DateTime vencimentoAte);
    }
}
