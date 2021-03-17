using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces.Servicos;
using Dominio.Entidades;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItensNdController : ControllerBase
    {
        IItensNdServico itensNdServico;

        public ItensNdController(IItensNdServico itensNdServico)
        {
            this.itensNdServico = itensNdServico;
        }

        [HttpGet]
        [Route("GetIdItensNdEDescricaoAlternativa")]
        public ItensNdController[] GetIdItensNdEDescricaoAlternativa()
        {
            try
            {
                var teste = itensNdServico.GetIdItensNdEDescricaoAlternativa();
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
