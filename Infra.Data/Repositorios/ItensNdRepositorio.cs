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
        public async Task<dynamic> GetIdItensNdEDescricaoAlternativa()
        {
            var consulta = contexto
                .ItensNds
                .Include(i => i.DescricaoAlternativaRubrica)
                .Select(i => new { i.Id, i.DescricaoAlternativaRubrica.NomeDescricaAlternativa })
                .ToListAsync();

            return await consulta;
        }
    }
}
