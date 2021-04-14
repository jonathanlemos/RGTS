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
    public class CidadeController : ControllerBase
    {
        ICidadeServico _municipioServico;

        public CidadeController(ICidadeServico municipioServico)
        {
            this._municipioServico = municipioServico;
        }

        [HttpGet]
        public Cidade[] Get()
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

        [HttpGet("{id}")]
        public Cidade[] Get(int id)
        {
            try
            {
                return _municipioServico.GetAll().Where(i=>i.EstadoId == id).ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
