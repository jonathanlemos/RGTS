﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces.Servicos
{
    public interface IItensNdServico : IServicoBase<ItensNd>
    {
        public Task<List<ItensNd>> GetIdItensNdEDescricaoAlternativa();
    }
}