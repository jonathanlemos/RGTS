using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("ContratoFaixasAluguel")]
    public partial class ContratoFaixasAluguel
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataBaseReajuste { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataBaseAtualizacao { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataInicioFaixa { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataFimFaixa { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        public decimal? ValorAluguel { get; set; }
        [Column("ValorParaFPP", TypeName = "decimal(15, 2)")]
        public decimal? ValorParaFpp { get; set; }
        public int? IdInstrumento { get; set; }
        [Column("eAtivo")]
        public bool? EAtivo { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
