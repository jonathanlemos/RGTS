using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Permissao")]
    public class Permissao
    {
        [Column("PermissaoId", TypeName = "int")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("Nome", TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [Column("Descricao", TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required]
        public string Descricao { get; set; }

        //[ForeignKey("Perfil")]
        //public int? PerfilId { get; set; }

        //[Column("Perfil", TypeName = "int")]
        //[ForeignKey("Perfil")]
        //public Perfil Perfil { get; set; }

        //[NotMapped]
        //[ForeignKey("Perfil")]
        public ICollection<Perfil> ListaPerfil { get; set; }
    }
}
