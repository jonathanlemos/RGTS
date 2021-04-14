using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Perfil")]
    public partial class Perfil
    {
        public Perfil()
        {
            PerfilPermissaos = new HashSet<PerfilPermissao>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }
        public int? PermissaoId { get; set; }

        [InverseProperty(nameof(PerfilPermissao.Perfil))]
        public virtual ICollection<PerfilPermissao> PerfilPermissaos { get; set; }
    }
}
