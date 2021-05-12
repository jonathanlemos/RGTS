using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces.Servicos
{
    public interface INdServico : IServicoBase<Nd>
    {
        List<Nd> filter(int tipoInstrumento, int[] lucs, int[] marcas, DateTime vencimentoDe, DateTime vencimentoAte);
    }
}
