using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("ND")]
    public partial class Nd
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdInstrumento { get; set; }
        public int? IdServicoCobranca { get; set; }
        public double? ValorOriginal { get; set; }
        public double? ValorPrincipal { get; set; }
        public double? ValorSaldo { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Vencimento { get; set; }
        public int? IdLiquidacao { get; set; }
        public int? IdCobranca { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Liquidacao { get; set; }
        [Column(TypeName = "decimal(12, 7)")]
        public decimal? PercentualMulta { get; set; }
        public int? IdTipoJuros { get; set; }
        [Column(TypeName = "decimal(12, 7)")]
        public decimal? PercentualJuros { get; set; }
        public int? PessoaBeneficiario { get; set; }
        public int? PessoaPagador { get; set; }
        [StringLength(20)]
        public string NossoNumero { get; set; }
        [StringLength(1)]
        public string DigitoNossoNumero { get; set; }
        [StringLength(50)]
        public string ArquivoRemessa { get; set; }
        [Column(TypeName = "date")]
        public DateTime? GeracaoArquivoRemessa { get; set; }
        [StringLength(50)]
        public string ArquivoRetorno { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TratamentoArquivoRetorno { get; set; }
        public int? IdFormaCriacao { get; set; }
        public int? Remessa { get; set; }
        public int? IdInclusao { get; set; }
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
