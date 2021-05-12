using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;

namespace Dominio.Serviços
{
    public class PapelServico : ServicoBase<Papel>, IPapelServico
    {
        private readonly IPapelRepositorio papelRepositorio;

        public PapelServico(IPapelRepositorio _papelRepositorio) : base(_papelRepositorio)
        {
            this.papelRepositorio = _papelRepositorio;
        }
    }
}