using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Permissao), StatusCodes.Status200OK)]
        public ActionResult<Permissao> Get(int id) =>  _permissaoServico.GetById(id);


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Permissao>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Permissao>> Get() => Ok(_permissaoServico.GetAll());
        

        [HttpPost]
        [ProducesResponseType(typeof(NotificacaoPost), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<NotificacaoPost> Salvar(Permissao perfil)
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
