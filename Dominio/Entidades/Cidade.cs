﻿using System;
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
        [Column("Estado_Id")]
        public int EstadoId { get; set; }

        [ForeignKey(nameof(EstadoId))]
        [InverseProperty(nameof(EstadoNovo.Cidades))]
        public virtual EstadoNovo Estado { get; set; }
    }
}
