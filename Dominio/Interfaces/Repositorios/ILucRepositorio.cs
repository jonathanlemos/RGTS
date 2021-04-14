using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios
{
    public interface ILucRepositorio : IRepositorioBase<Luc>
    {
        public Task<Luc> GetPorNome(string nome);
    }
}
