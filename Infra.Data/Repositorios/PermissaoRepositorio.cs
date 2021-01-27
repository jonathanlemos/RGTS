using Dominio.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dominio.Interfaces.Repositorios;

namespace Infra.Data.Repositorios
{
    public class PermissaoRepositorio : RepositorioBase<Permissao>, IPermissaoRepositorio
    {
        public IEnumerable<Permissao> ObterTodasPermissoes()
        {
            return GetAll();
        }

        //public IEnumerable<Permissao> ObterTodasPermissoesDoUsuario(Usuario usuario)
        //{
        //    return contexto.Usuario.Where(i=>i.Id == usuario.Id).SelectMany(i=>i.ListaPermissao).ToList();
        //}
    }
}
