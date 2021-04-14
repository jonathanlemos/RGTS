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
        private readonly ILucRepositorio lucRepositorio;

        public ItensNdServico(IItensNdRepositorio itensNdRepositorio, ILucRepositorio lucRepositorio) : base(itensNdRepositorio)
        {
            this.itensNdRepositorio = itensNdRepositorio;
            this.lucRepositorio = lucRepositorio;
        }

        public Task<List<ItensNd>> GetIdItensNdEDescricaoAlternativa()
        {
            return itensNdRepositorio.GetIdItensNdEDescricaoAlternativa();
        }
    }
}
