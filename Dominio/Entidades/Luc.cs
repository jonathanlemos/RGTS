using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Luc")]
    public partial class Luc
    {
        public int? IdShopping { get; set; }
        [Key]
        public int Id { get; set; }
        [Column("NomeLUC")]
        [StringLength(100)]
        public string NomeLuc { get; set; }
        public int? IdClassificacao { get; set; }
        [Column(TypeName = "numeric(17, 2)")]
        public decimal? AreaM2 { get; set; }
        [Column("CRD")]
        public double? Crd { get; set; }
        [Column("PotenciaTR")]
        public double? PotenciaTr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        public int? IdFase { get; set; }
        public int? IdLocalizacao { get; set; }
        public int? IdNivel { get; set; }
        public int? IdEmpreendimento { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
