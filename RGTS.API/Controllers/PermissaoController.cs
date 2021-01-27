using Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RGTS.API.Controllers
{
    public class PermissaoController
    {
        IUsuarioServico _usuarioServico;

        public PermissaoController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public IActionResult Get(int id)
        {
            //return Request. _usuarioServico.GetById(id);
            return null;
        }
    }
}
