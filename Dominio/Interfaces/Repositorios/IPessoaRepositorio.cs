using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Repositorios
{
    public interface IPessoaRepositorio : IRepositorioBase<Pessoa>
    {
        Pessoa ObterDadosUsuario(Pessoa usuario);

        IEnumerable<Pessoa> ObterTodosUsuarios();

        void CadastrarNovoUsuario(Pessoa usuario);
    }
}
