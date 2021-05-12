using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("ItensNdRecebido")]
    public partial class ItensNdRecebido
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        [Column("IdND")]
        public int? IdNd { get; set; }
        [Column("IdItemND")]
        public int? IdItemNd { get; set; }
        public int? Transacao { get; set; }
        public int? IdTipoBaixa { get; set; }
        public double? ValorRecebidoPrincipal { get; set; }
        public double? ValorRecebidoCorrecao { get; set; }
        public double? ValorRecebidoMulta { get; set; }
        public double? ValorRecebidoJuros { get; set; }
        public double? ValorConcedidoDesconto { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataReversao { get; set; }
    }
}
