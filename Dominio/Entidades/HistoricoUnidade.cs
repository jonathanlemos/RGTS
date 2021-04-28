using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("HistoricoUnidade")]
    public partial class HistoricoUnidade
    {
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdUnidade { get; set; }
        public int? MesProcessamento { get; set; }
        public int? AnoProcessamento { get; set; }
        [Column("M2ABL", TypeName = "decimal(8, 2)")]
        public decimal? M2abl { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataDesativacao { get; set; }
        public int? IdTipoUnidade { get; set; }
    }
}
