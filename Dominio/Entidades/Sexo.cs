using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Sexo")]
    public partial class Sexo
    {
        public Sexo()
        {
            Pessoas = new HashSet<Pessoa>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Descricao { get; set; }

        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
