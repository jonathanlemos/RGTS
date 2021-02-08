using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Serviços
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio) : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.CadastrarNovoUsuario(usuario);
        }

        public void AtualizarUsuarios(Usuario[] usuarios)
        {
            for (var i=0; i< usuarios.Length; i++)
            {
                _usuarioRepositorio.Update(usuarios[i]);
            }
        }
    }
}
