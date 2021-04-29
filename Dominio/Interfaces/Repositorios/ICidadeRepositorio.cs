using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorios
{
    public interface ICidadeRepositorio : IRepositorioBase<Cidade>
    {
        Cidade GetByIdComEstado(int id);
        Task<List<Cidade>> GetAllComEstado();
    }
}
