using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class PartilhaBancariaServico: ServicoBase<PartilhaBancarium>, IPartilhaBancariaServico
    {
        private readonly IPartilhaBancariaRepositorio partilhaRepositorio;
        public PartilhaBancariaServico(IPartilhaBancariaRepositorio repositorio) : base(repositorio)
        {
            this.partilhaRepositorio = repositorio;
        }
    }
}
