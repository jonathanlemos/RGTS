using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
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
