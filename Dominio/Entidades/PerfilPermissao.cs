using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("PerfilPermissao")]
    public partial class PerfilPermissao
    {
        [Required]
        [StringLength(10)]
        public string Id { get; set; }
        public int PerfilId { get; set; }
        public int PermissaoId { get; set; }
    }
}
