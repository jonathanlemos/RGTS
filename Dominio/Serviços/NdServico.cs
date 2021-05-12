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
    public class NdServico : ServicoBase<Nd>, INdServico
    {
        private readonly INdRepositorio ndRepositorio;

        public NdServico(INdRepositorio _ndRepositorio) : base(_ndRepositorio)
        {
            this.ndRepositorio = _ndRepositorio;
        }

        public List<Nd> filter(int tipoInstrumento, int[] lucs, int[] marcas, DateTime vencimentoDe, DateTime vencimentoAte)
        {
            return this.ndRepositorio.filter(tipoInstrumento, lucs, marcas, vencimentoDe, vencimentoAte);
        }
    }
}
