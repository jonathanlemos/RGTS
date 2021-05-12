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
    public class ServicoCobrancaController : ControllerBase
    {
        IServicoCobrancaServico _servicoCobranca;

        public ServicoCobrancaController(IServicoCobrancaServico servicoCobranca)
        {
            this._servicoCobranca = servicoCobranca;
        }

        [HttpGet]
        public ServicoCobranca[] Get()
        {
            try
            {
                return _servicoCobranca.GetAll()
                    .Select(i => new ServicoCobranca { Id = i.Id, NomeServico = i.NomeServico })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;

            }
        }
    }
}