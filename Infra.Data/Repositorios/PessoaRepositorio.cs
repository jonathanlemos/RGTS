using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Repositorios
{
    public class PessoaRepositorio : RepositorioBase<Pessoa>, IPessoaRepositorio
    {
        public void CadastrarNovoUsuario(Pessoa usuario)
        {
            //usuario.DataAlteracao = DateTime.Now;
            usuario.DataInsercao = DateTime.Now;
            usuario.Ativo = true;
            Add(usuario);
        }

        public Pessoa ObterDadosUsuario(Pessoa usuario)
        {
            return GetById(usuario.Id);
        }

        public IEnumerable<Pessoa> ObterTodosUsuarios()
        {
            return GetAll();
        }


    }
}
