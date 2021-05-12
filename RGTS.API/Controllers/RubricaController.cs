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
    public class RubricaController : ControllerBase
    {
        IRubricaServico rubricaServico;

        public RubricaController(IRubricaServico rubricaServico)
        {
            this.rubricaServico = rubricaServico;
        }

        [HttpGet]
        public Rubrica[] Get()
        {
            try
            {
                return rubricaServico.GetAll()
                    .Select(i => new Rubrica { Id = i.Id, NomeRubrica = i.NomeRubrica, IdSerie = i.IdSerie })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
