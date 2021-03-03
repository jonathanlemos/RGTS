using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Fase")]
    public partial class Fase
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeFase { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
