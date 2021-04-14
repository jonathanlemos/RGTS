using Dominio.Interfaces;
using Dominio.Interfaces.Repositorios;
using Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        //protected RGTSContext contexto = new RGTSContext();
        protected RGTSDbContext contexto = new RGTSDbContext();

        public void Add(TEntity entidade)
        {
            contexto.Set<TEntity>().Add(entidade);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public TEntity GetById(int id)
        {
            return contexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                //AsNoTracking=retorna os dados sem carregamento
                return contexto.Set<TEntity>().AsNoTracking().ToList();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public void Remove(TEntity entidade)
        {
            contexto.Set<TEntity>().Remove(entidade);
            contexto.SaveChanges();
        }

        public void Update(TEntity entidade)
        {
            contexto.Entry(entidade).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
