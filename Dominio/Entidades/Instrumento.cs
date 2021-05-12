using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Instrumento")]
    public partial class Instrumento
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdTipoInstrumento { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Assinatura { get; set; }
        public int? IdTipoJuros { get; set; }
        public int? IdTipoCorrecao { get; set; }
        public int? IdFormaCorrecao { get; set; }
        public int? IdInstrumentoOrigem { get; set; }
        public int? IdTipoInstrumentoOrigem { get; set; }
        [ForeignKey("locacao")]
        public int? IdInstrumentoContrato { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        public virtual ContratoLocacao locacao { get; set; }
    }
}
