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
    public class ContratoLucsController : ControllerBase
    {
        IContratoLucsServico _contratoLucsServico;

        public ContratoLucsController(IContratoLucsServico contratoLucsServico)
        {
            this._contratoLucsServico = contratoLucsServico;
        }

        [HttpGet]
        public ContratoLuc[] Get()
        {
            try
            {
                return _contratoLucsServico.GetAll()
                    .Select(i => new ContratoLuc { Id = i.Id, IdInstrumento = i.IdInstrumento })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("luc/{idLuc}")]
        public ContratoLuc GetIdInstrumentoByLucId(int idLuc)
        {
            try
            {
                return _contratoLucsServico.GetInstrumentoIdByLucId(idLuc);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("instrumento/{idInstrumento}")]
        public ContratoLuc GetIdLucByInstrumentoId(int idInstrumento)
        {
            try
            {
                return _contratoLucsServico.GetLucIdByInstrumentoId(idInstrumento);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
