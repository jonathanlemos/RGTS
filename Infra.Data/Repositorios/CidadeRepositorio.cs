using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class CidadeRepositorio : RepositorioBase<Cidade>, ICidadeRepositorio
    {
        public Cidade GetByIdComEstado(int id)
        {
            return contexto.Cidades
                .Include(i=>i.Estado)
                .Where(i => i.Id == id)
                .FirstOrDefault();
        }

        public Task<List<Cidade>> GetAllComEstado()
        {
            return contexto.Cidades
                .Include(i=>i.Estado)
                .ToListAsync();
        }
    }
}
