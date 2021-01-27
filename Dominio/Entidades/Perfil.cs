using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Perfil")]
    public class Perfil
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

        [NotMapped]
        public ICollection<Permissao> ListaPermissao { get; set; }
    }
}
