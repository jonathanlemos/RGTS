using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RGTS.API.Models
{
    public class ImportarValoresDeConsumoModel
    {
        public Luc Luc { get; set; }
        public ValoresFaturado ValoresFaturado { get; set; }
        public Rubrica Rubrica { get; set; }
    }
}
