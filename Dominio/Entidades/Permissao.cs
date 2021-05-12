using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Permissao")]
    public partial class Permissao
    {
        public Permissao()
        {
            PerfilPermissaos = new HashSet<PerfilPermissao>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }
        public int? PerfilId { get; set; }

        [InverseProperty(nameof(PerfilPermissao.Permissao))]
        public virtual ICollection<PerfilPermissao> PerfilPermissaos { get; set; }
    }
}
