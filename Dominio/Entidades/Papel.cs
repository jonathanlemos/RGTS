using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Papel")]
    public partial class Papel
    {
        public int? Id { get; set; }
        [StringLength(50)]
        public string NomePapel { get; set; }
        public int? IdTipoInstrumento { get; set; }
    }
}
