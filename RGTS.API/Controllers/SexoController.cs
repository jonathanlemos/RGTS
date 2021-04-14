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
    public class SexoController : ControllerBase
    {
        ISexoRepositorio sexoRepositoio;
        public SexoController(ISexoRepositorio _sexoRepositoio)
        {
            sexoRepositoio = _sexoRepositoio;
        }

        [HttpGet]
        public Sexo[] Get()
        {
            try
            {
                var ret = sexoRepositoio.GetAll().ToArray();
                return ret;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
