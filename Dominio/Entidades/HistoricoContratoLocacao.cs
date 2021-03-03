using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("HistoricoContratoLocacao")]
    public partial class HistoricoContratoLocacao
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? MesProcessamento { get; set; }
        public int? AnoProcessamento { get; set; }
        public int? AblM2 { get; set; }
        public int? IdRamo { get; set; }
        public int? IdAtividade { get; set; }
        public int? IdUnidade { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataDistrato { get; set; }
        [Column(TypeName = "date")]
        public DateTime? InicioVigencia { get; set; }
        public int? IdTipoContrato { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FimVigencia { get; set; }
        public int? IdSeqAlteracaoContratoLocacao { get; set; }
    }
}
