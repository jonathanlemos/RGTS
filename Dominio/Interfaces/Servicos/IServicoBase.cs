﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Add(TEntity entidade);
        void Update(TEntity entidade);
        void Remove(TEntity entidade);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
