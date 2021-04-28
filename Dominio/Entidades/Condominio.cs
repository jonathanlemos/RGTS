using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Condominio")]
    public partial class Condominio
    {
        public int? IdShoppint { get; set; }
        public int Id { get; set; }
        public int? IdEmpreendimento { get; set; }
        [StringLength(100)]
        public string NomeCondominio { get; set; }
        public int? TipoRateio { get; set; }
        [Column(TypeName = "decimal(12, 7)")]
        public decimal? PercentualVacancia { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInsercao { get; set; }
    }
}
