using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("PartilhaRubricaContaCorrente")]
    public partial class PartilhaRubricaContaCorrente
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdEmpreendimento { get; set; }
        public int? IdServicoCobranca { get; set; }
        public int? IdContaCorrente { get; set; }
        public int? IdRubrica { get; set; }
        public int? IdDescricaoAlternativa { get; set; }
        [Column(TypeName = "decimal(12, 7)")]
        public decimal? PercentualPartilhaRubrica { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
