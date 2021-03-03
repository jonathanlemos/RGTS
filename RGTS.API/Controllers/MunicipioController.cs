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
    public class MunicipioController : ControllerBase
    {
        IMunicipioServico _municipioServico;

        public MunicipioController(IMunicipioServico municipioServico)
        {
            this._municipioServico = municipioServico;
        }

        [HttpGet]
        public Municipio[] Get()
        {
            try
            {
                return _municipioServico.GetAll().ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
