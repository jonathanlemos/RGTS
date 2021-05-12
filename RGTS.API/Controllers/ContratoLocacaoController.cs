using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ValueType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoLocacaoController : ControllerBase
    {
        IContratoLocacaoServico _contratoLocacaoServico;

        public ContratoLocacaoController(IContratoLocacaoServico contratoLocacaoServico)
        {
            this._contratoLocacaoServico = contratoLocacaoServico;
        }

        [HttpGet]
        public ContratoLocacao[] Get()
        {
            try
            {
                return _contratoLocacaoServico.GetAll()
                    .Select(i => new ContratoLocacao { Id = i.Id, IdInstrumento = i.IdInstrumento })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("instrumento/{idInstrumento}")]
        public ContratoLocacao GetByIdInstrumento(int idInstrumento)
        {
            try
            {
                var cl = _contratoLocacaoServico.GetByIdInstrumento(idInstrumento);
                return cl;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
