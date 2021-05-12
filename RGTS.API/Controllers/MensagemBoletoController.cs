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
    public class MensagemBoletoController : ControllerBase
    {
        IMensagemBoletoServico _mensagemBoleto;

        public MensagemBoletoController(IMensagemBoletoServico mensagemBoleto)
        {
            this._mensagemBoleto = mensagemBoleto;
        }

        [HttpGet]
        public MensagemBoleto[] Get()
        {
            try
            {
                return _mensagemBoleto.GetAll()
                    .Select(i => new MensagemBoleto { Id = i.Id, NomeMensagem = i.NomeMensagem })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;

            }
        }
    }
}