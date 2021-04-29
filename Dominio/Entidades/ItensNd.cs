using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("ItensND")]
    public partial class ItensNd
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        [Column("IdND")]
        public int IdNd { get; set; }
        public double? ValorSaldoRubrica { get; set; }
        public double? ValorPrincipalRubrica { get; set; }
        public double? ValorOriginalRubrica { get; set; }
        public int? IdItemRubrica { get; set; }
        public int? IdDescricaoAlternativa { get; set; }
        public int? AnoCompetencia { get; set; }
        public int? MesCompetencia { get; set; }
        [Column("eNegociado")]
        public bool? ENegociado { get; set; }
        public int? NumeroNegociacao { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataAlteracao { get; set; }

        [ForeignKey(nameof(IdNd))]
        [InverseProperty(nameof(Nd.ItensNds))]
        public virtual Nd IdNdNavigation { get; set; }
    }
}
