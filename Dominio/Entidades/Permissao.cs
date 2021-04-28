using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Permissao")]
    public partial class Permissao
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }
        public int? PerfilId { get; set; }
    }
}
