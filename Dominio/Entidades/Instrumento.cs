using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Instrumento")]
    public partial class Instrumento
    {
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdTipoInstrumento { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Assinatura { get; set; }
        public int? IdTipoJuros { get; set; }
        public int? IdTipoCorrecao { get; set; }
        public int? IdFormaCorrecao { get; set; }
        public int? IdInstrumentoOrigem { get; set; }
        [StringLength(10)]
        public string IdTipoInstrumentoOrigem { get; set; }
        [StringLength(10)]
        public string IdInstrumentoContrato { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
