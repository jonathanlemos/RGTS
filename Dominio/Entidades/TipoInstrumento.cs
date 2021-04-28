using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("TipoInstrumento")]
    public partial class TipoInstrumento
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string NomeInstrumento { get; set; }
        public int? Ordem { get; set; }
        [Column("eCobranca")]
        public bool? ECobranca { get; set; }
    }
}
