using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos
{
    public class EstadoServico : ServicoBase<Estado>, IEstadoServico
    {
        private readonly IEstadoRepositorio estadoRepositorio;

        public EstadoServico(IEstadoRepositorio estadoRepositorio) : base(estadoRepositorio)
        {
            this.estadoRepositorio = estadoRepositorio;
        }
    }
}
