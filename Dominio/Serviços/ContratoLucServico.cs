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
    public class ContratoLucServico : ServicoBase<ContratoLuc>, IContratoLucServico
    {
        private readonly IContratoLucRepositorio contratoLucRepositorio;

        public ContratoLucServico(IContratoLucRepositorio contratoLucRepositorio) : base(contratoLucRepositorio)
        {
            this.contratoLucRepositorio = contratoLucRepositorio;
        }
    }
}
