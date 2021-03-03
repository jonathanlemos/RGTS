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
    public class EstadoController : ControllerBase
    {
        IEstadoServico _estadoServico;

        public EstadoController(IEstadoServico estadoServico)
        {
            this._estadoServico = estadoServico;
        }

        [HttpGet]
        public Estado[] Get()
        {
            try
            {
                return _estadoServico.GetAll().ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
