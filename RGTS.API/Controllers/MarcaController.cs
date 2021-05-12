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
    public class MarcaController : ControllerBase
    {
        IMarcaServico marcaServico;

        public MarcaController(IMarcaServico marcaServico)
        {
            this.marcaServico = marcaServico;
        }

        [HttpGet]
        public Marca[] Get()
        {
            try
            {
                return marcaServico.GetAll()
                    .Select(i => new Marca { Id = i.Id, NomeMarca = i.NomeMarca })
                    .ToArray();
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
