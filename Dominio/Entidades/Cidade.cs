using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Cidade")]
    public partial class Cidade
    {
        public Cidade()
        {
            Pessoas = new HashSet<Pessoa>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [ForeignKey("Estado")]
        public int EstadoId { get; set; }


        public virtual Estado Estado { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
