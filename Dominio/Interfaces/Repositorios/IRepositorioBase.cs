using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Add(TEntity entidade);
        void Update(TEntity entidade);
        void Remove(TEntity entidade);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
        IQueryable<TEntity> Get(Func<TEntity, bool> where);
    }
}
