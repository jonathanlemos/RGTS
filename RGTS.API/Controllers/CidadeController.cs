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
using Microsoft.EntityFrameworkCore;

namespace RGTS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        ICidadeRepositorio _cidadeRepositorio;

        public CidadeController(ICidadeRepositorio _cidadeRepositorio)
        {
            this._cidadeRepositorio = _cidadeRepositorio;
        }

        [HttpGet]
        public Task<List<Cidade>> Get()
        {
            try
            {
                var ret = _cidadeRepositorio.GetAllComEstado();
                var ret1 = ret.Result;
                return ret;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public Cidade Get(int id)
        {
            try
            {
                var ret = _cidadeRepositorio.GetByIdComEstado(id);
                return ret;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("{estadoId}")]
        public Cidade[] GetCidadesPorEstadoId(int estadoId)
        {
            try
            {
                var ret = _cidadeRepositorio.GetAll().Where(i => i.EstadoId == estadoId).ToArray();
                return ret;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
