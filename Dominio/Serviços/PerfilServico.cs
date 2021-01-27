using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class PerfilServico : ServicoBase<Perfil>, IPerfilServico
    {
        private readonly IPerfilRepositorio _perfilRepositorio;

        public PerfilServico(IPerfilRepositorio perfilRepositorio) : base(perfilRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
        }
    }
}
