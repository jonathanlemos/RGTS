using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entidades;

namespace Dominio.Interfaces.Repositorios
{
    public interface IItensNdRepositorio : IRepositorioBase<ItensNd>
    {
        public IEnumerable<ItensNd> GetIdItensNdEDescricaoAlternativa();
    }
}
