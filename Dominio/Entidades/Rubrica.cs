using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Rubrica")]
    public partial class Rubrica
    {
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        [StringLength(100)]
        public string NomeRubrica { get; set; }
        public int? IdGrupoRubrica { get; set; }
        public int? IdSerie { get; set; }
        public int? DiaVencimento { get; set; }
        public int? IdTipoIsto { get; set; }
        [Column("eVencido")]
        public bool? EVencido { get; set; }
        [StringLength(100)]
        public string UsuarioInsercao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column("eAtivo")]
        public bool? EAtivo { get; set; }
        [Column("eDesconto")]
        public bool? EDesconto { get; set; }
        [Column("eEncargo")]
        public bool? EEncargo { get; set; }
        [Column("eImportavel")]
        public bool? EImportavel { get; set; }
    }
}
