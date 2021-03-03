using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class MunicipioServico : ServicoBase<Municipio>, IMunicipioServico
    {
        private readonly IMunicipioRepositorio municipioRepositorio;

        public MunicipioServico(IMunicipioRepositorio _municipioRepositorio) : base(_municipioRepositorio)
        {
            this.municipioRepositorio = _municipioRepositorio;
        }
    }
}
