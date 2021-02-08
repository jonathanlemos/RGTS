using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico : IServicoBase<Usuario>
    {
        public void CadastrarUsuario(Usuario usuario);

        public void AtualizarUsuarios(Usuario[] usuario);
    }
}
