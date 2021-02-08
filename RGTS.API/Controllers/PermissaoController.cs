using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissaoController : ControllerBase
    {
        IPermissaoServico _permissaoServico;

        public PermissaoController(IPermissaoServico permissaoServico)
        {
            _permissaoServico = permissaoServico;
        }

        [HttpGet]
        public Permissao Get(int id)
        {
            return _permissaoServico.GetById(id);
        }

        [HttpGet]
        public Permissao[] Get()
        {
            return _permissaoServico.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<NotificacaoPost> Post(Permissao perfil)
        {
            try
            {
                _permissaoServico.SalvarPermissao(perfil);
                return new NotificacaoPost();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
