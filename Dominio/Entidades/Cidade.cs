using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Cidade")]
    public class Cidade
    {
        [Column("Id", TypeName = "int")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("Nome", TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }
    }
}
