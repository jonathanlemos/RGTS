using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("GrupoRubrica")]
    public partial class GrupoRubrica
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeGrupoRubrica { get; set; }
        [Column("eFaturamento")]
        public bool? EFaturamento { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
