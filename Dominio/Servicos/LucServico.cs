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
    public class LucServico : ServicoBase<Luc>, ILucServico
    {
        private readonly ILucRepositorio lucRepositorio;

        public LucServico(ILucRepositorio lucRepositorio) : base(lucRepositorio)
        {
            this.lucRepositorio = lucRepositorio;
        }

        public async Task<Luc> GetPorNome(string nome)
        {
            return await lucRepositorio.GetPorNome(nome);
        }
    }
}