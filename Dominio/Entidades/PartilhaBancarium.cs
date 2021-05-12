using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("PartilhaBancarium")]
    public partial class PartilhaBancarium
    {
        public PartilhaBancarium()
        {
        }

        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdEmpreendimento { get; set; }
        [ForeignKey("servicoCobranca")]
        public int? IdServicoCobranca { get; set; }
        [ForeignKey("contaCorrente")]
        public int? IdContaCorrente { get; set; }
        public int? IdRubrica { get; set; }
        public int? IdDescricaoAlternativa { get; set; }
        [Column(TypeName = "decimal(12, 7)")]
        public decimal? PercentualPartilha { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        
        public virtual ContaCorrente contaCorrente { get; set; }
        
        public virtual ServicoCobranca servicoCobranca { get; set; }

        public virtual ICollection<ItensNdPartilhado> itensNdPartilhado { get; set; }
    }
}
