using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    public partial class ValoresFaturado
    {
        [Key]
        public int Id { get; set; }
        [Column("IdND")]
        public int? IdNd { get; set; }
        [Column("IdItemND")]
        public int? IdItemNd { get; set; }
        public int? IdRubrica { get; set; }
        public int? MesCompetencia { get; set; }
        public int? AnoCompetencia { get; set; }
        public int? MesProcessamento { get; set; }
        [StringLength(10)]
        public string AnoProcessamento { get; set; }
        public double? ValorCalculado { get; set; }
        public double? ValorFaturado { get; set; }
        [Column("VencimentoND", TypeName = "date")]
        public DateTime? VencimentoNd { get; set; }
        public int? IdSerie { get; set; }
        [Column("eAprovado")]
        public bool? EAprovado { get; set; }
        [StringLength(100)]
        public string Documento { get; set; }
        public int? IdSeqAltContratoLocacao { get; set; }
        public int? IdInstrumento { get; set; }
        public int? IdDescricaoAlternativa { get; set; }
        [StringLength(100)]
        public string UsuarioInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
