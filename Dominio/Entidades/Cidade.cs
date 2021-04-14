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
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        public int EstadoId { get; set; }

        [ForeignKey(nameof(EstadoId))]
        [InverseProperty("Cidades")]
        public virtual Estado Estado { get; set; }
    }
}
