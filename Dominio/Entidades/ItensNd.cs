using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("ItensNd")]
    public partial class ItensNd
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        [ForeignKey("nd")]
        public int IdNd { get; set; }
        public double? ValorSaldoRubrica { get; set; }
        public double? ValorPrincipalRubrica { get; set; }
        public double? ValorOriginalRubrica { get; set; }
        [ForeignKey("rubrica")]
        public int? IdRubrica { get; set; }
        public int? IdDescricaoAlternativa { get; set; }
        public int? AnoCompetencia { get; set; }
        public int? MesCompetencia { get; set; }
        [Column("eNegociado")]
        public bool? ENegociado { get; set; }
        public int? NumeroNegociacao { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        public double? ValorCorrecaoRubrica { get; set; }
        public double? ValorMultaRubrica { get; set; }
        public double? ValorJurosRubrica { get; set; }
        public virtual Rubrica rubrica { get; set; }
        
        public virtual Nd nd { get; set; }
    }
}
