using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public void CadastrarNovoUsuario(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.Ativo = true;

            Add(usuario);
        }

        public Usuario ObterDadosUsuario(Usuario usuario)
        {
            return GetById(usuario.Id);
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            return GetAll();
        }


    }
}
