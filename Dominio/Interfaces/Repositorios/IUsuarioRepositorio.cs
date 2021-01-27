using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario ObterDadosUsuario(Usuario usuario);

        IEnumerable<Usuario> ObterTodosUsuarios();

        void CadastrarNovoUsuario(Usuario usuario);
    }
}
