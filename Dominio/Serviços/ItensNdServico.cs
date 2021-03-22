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
    public class ItensNdServico : ServicoBase<ItensNd>, IItensNdServico
    {
        private readonly IItensNdRepositorio itensNdRepositorio;

        public ItensNdServico(IItensNdRepositorio itensNdRepositorio) : base(itensNdRepositorio)
        {
            this.itensNdRepositorio = itensNdRepositorio;
        }

        public Task<dynamic> GetIdItensNdEDescricaoAlternativa()
        {
            return itensNdRepositorio.GetIdItensNdEDescricaoAlternativa();
        }
    }
}
