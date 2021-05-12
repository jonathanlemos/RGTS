using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("PerfilPermissao")]
    public partial class PerfilPermissao
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        public int PerfilId { get; set; }
        public int PermissaoId { get; set; }

        [ForeignKey(nameof(PerfilId))]
        [InverseProperty("PerfilPermissaos")]
        public virtual Perfil Perfil { get; set; }
        [ForeignKey(nameof(PermissaoId))]
        [InverseProperty("PerfilPermissaos")]
        public virtual Permissao Permissao { get; set; }
    }
}
