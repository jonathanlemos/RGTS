using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoInstrumentoController : ControllerBase
    {
        ITipoInstrumentoServico tipoInstrumentoServico;

        public TipoInstrumentoController(ITipoInstrumentoServico tipoInstrumentoServico)
        {
            this.tipoInstrumentoServico = tipoInstrumentoServico;
        }

        [HttpGet]
        public TipoInstrumento[] Get()
        {
            try
            {
                return tipoInstrumentoServico.GetAll()
                    .Select(i => new TipoInstrumento { Id = i.Id, NomeInstrumento = i.NomeInstrumento })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
