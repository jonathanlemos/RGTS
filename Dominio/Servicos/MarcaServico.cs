using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;

namespace Dominio.Servicos
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
