using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Empreendimento")]
    public partial class Empreendimento
    {
        public int? IdShopping { get; set; }
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeEmpreendimento { get; set; }
        public int? IdPessoa { get; set; }
        [StringLength(100)]
        public string UsuarioInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
    }
}
