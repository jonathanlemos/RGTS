using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("PessoaPapelInstrumento")]
    public partial class PessoaPapelInstrumento
    {
        [Key]
        public int Id { get; set; }
        public int? IdSequencial { get; set; }
        public int? IdInstrumento { get; set; }
        public int? IdPessoa { get; set; }
        public int? IdPapel { get; set; }
        [Column("eAtivo")]
        public bool? EAtivo { get; set; }
    }
}
