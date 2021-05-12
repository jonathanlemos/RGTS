using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("ItensNdPartilhado")]
    public partial class ItensNdPartilhado
    {
        [Key]
        public int Id { get; set; }
        public int? IdItemNd { get; set; }
        public int? IdShopping { get; set; }
        public int? Transacao { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Percentual { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Valor { get; set; }
        [ForeignKey("partilhaBancarium")]
        public int? IdPartilhaBancaria { get; set; }
        
        public virtual PartilhaBancarium partilhaBancarium { get; set; }
    }
}
