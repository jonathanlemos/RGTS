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
    public class ItensNdRepositorio : RepositorioBase<ItensNd>, IItensNdRepositorio
    {
        public async Task<List<ItensNd>> GetIdItensNdEDescricaoAlternativa()
        {
            return await contexto
                .ItensNds
                //.Include(i => i.DescricaoAlternativaRubrica)
                .ToListAsync();
        }
    }
}
