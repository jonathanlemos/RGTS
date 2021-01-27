using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Estado")]
    public class Estado
    {
        [Column("Id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }
    }
}
