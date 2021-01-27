using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entidades;
using Dominio.Interfaces;
using System.Linq;
using Dominio.Interfaces.Repositorios;

namespace Infra.Data.Repositorios
{
    public class PerfilRepositorio : RepositorioBase<Perfil>, IPerfilRepositorio
    {
        public IEnumerable<Perfil> GetAll()
        {
            return GetAll();
        }

        //public IEnumerable<Perfil> ObterPerfisUsuario(Usuario usuario)
        //{
        //    return contexto.Usuario.Where(i => i.Id == usuario.Id).SelectMany(i => i.ListaPerfil).ToList();
        //}
    }
}
