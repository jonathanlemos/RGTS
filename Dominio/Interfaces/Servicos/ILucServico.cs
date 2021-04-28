﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces.Servicos
{
    public interface ILucServico : IServicoBase<Luc> 
    {
        public Task<Luc> GetPorNome(string nome);
    }
}