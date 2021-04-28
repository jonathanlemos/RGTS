using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class ContratoLucRepositorio : RepositorioBase<ContratoLuc>, IContratoLucRepositorio
    {
    }
}
