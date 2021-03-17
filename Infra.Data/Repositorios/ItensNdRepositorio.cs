using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class ItensNdRepositorio : RepositorioBase<ItensNd>, IItensNdRepositorio
    {
        public IEnumerable<ItensNd> GetIdItensNdEDescricaoAlternativa()
        {
            string consulta = @"select da.id, da.NomeDescricaAlternativa from [dbo].[ItensND] ind --itens cobrança
                                inner join [dbo].[DescricaoAlternativaRubrica]  da on da.Id = ind.IdDescricaoAlternativa;";

            var teste = contexto.ItensNds.FromSqlRaw(consulta).ToListAsync();
            
            return contexto.ItensNds.FromSqlRaw(consulta);
        }
    }
}
