using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class MarcaServico : ServicoBase<Marca>, IMarcaServico
    {
        private readonly IMarcaRepositorio marcaRepositorio;

        public MarcaServico(IMarcaRepositorio marcaRepositorio) : base(marcaRepositorio)
        {
            this.marcaRepositorio = marcaRepositorio;
        }
    }
}
