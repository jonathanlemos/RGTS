using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("DescricaoAlternativaRubrica")]
    public partial class DescricaoAlternativaRubrica
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        [StringLength(50)]
        public string NomeDescricaAlternativa { get; set; }
        [ForeignKey("rubrica")]
        public int? IdRubrica { get; set; }
        [StringLength(100)]
        public string UsuarioInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        
        public virtual Rubrica rubrica { get; set; }
    }
}
