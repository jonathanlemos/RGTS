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
    public class LucRepositorio : RepositorioBase<Luc>, ILucRepositorio
    {
        public async Task<Luc> GetPorNome(string nome)
        {
            return await contexto
                .Lucs
                .Where(i=>i.NomeLuc == nome).FirstOrDefaultAsync();
        }
    }
}
