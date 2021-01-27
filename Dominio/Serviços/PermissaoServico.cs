using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class PermissaoServico : ServicoBase<Permissao>, IPermissaoServico
    {
        private readonly IPermissaoRepositorio _permissaoRepositorio;

        public PermissaoServico(IPermissaoRepositorio permissaoRepositorio) : base(permissaoRepositorio)
        {
            _permissaoRepositorio = permissaoRepositorio;
        }
    }
}
