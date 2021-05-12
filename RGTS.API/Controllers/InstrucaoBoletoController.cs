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
    public class InstrucaoBoletoController : ControllerBase
    {
        IInstrucaoBoletoServico _instrucaoBoleto;

        public InstrucaoBoletoController(IInstrucaoBoletoServico instrucaoBoleto)
        {
            this._instrucaoBoleto = instrucaoBoleto;
        }

        [HttpGet]
        public InstrucaoBoleto[] Get()
        {
            try
            {
                return _instrucaoBoleto.GetAll()
                    .Select(i => new InstrucaoBoleto { Id = i.Id, NomeInstrucao = i.NomeInstrucao })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;

            }
        }
    }
}