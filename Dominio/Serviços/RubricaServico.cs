using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class RubricaServico : ServicoBase<Rubrica>, IRubricaServico
    {
        private readonly IRubricaRepositorio rubricaRepositorio;

        public RubricaServico(IRubricaRepositorio rubricaRepositorio) : base(rubricaRepositorio)
        {
            this.rubricaRepositorio = rubricaRepositorio;
        }
    }
}
