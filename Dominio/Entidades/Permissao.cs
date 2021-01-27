using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    public class Permissao
    {
        [Column("Id", TypeName = "int")]
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

        //[Column("PerfilId", TypeName = "int")]
        //[ForeignKey("Perfil")]
        //public Perfil Perfil { get; set; }

        [NotMapped]
        public ICollection<Perfil> ListaPerfil { get; set; }
    }
}
