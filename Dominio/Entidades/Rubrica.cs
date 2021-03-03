using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Rubrica")]
    public partial class Rubrica
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeRubrica { get; set; }
        public int? IdGrupoRubrica { get; set; }
        public int? IdTipoIsto { get; set; }
        [Column("eVencido")]
        public bool? EVencido { get; set; }
        [StringLength(100)]
        public string UsuarioInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
