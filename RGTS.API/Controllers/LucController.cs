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
    public class LucController : ControllerBase
    {
        ILucServico lucServico;

        public LucController(ILucServico lucServico)
        {
            this.lucServico = lucServico;
        }

        [HttpGet]
        public Luc[] Get()
        {
            try
            {
                return lucServico.GetAll()
                    .Select(i => new Luc { Id = i.Id, NomeLuc = i.NomeLuc })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
