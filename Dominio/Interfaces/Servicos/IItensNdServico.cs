using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entidades;

namespace Dominio.Interfaces.Servicos
{
    public interface IItensNdServico : IServicoBase<ItensNd>
    {
        public IEnumerable<ItensNd> GetIdItensNdEDescricaoAlternativa();
    }
}
