﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Estado")]
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }
        public int Regiao { get; set; }

        [InverseProperty(nameof(Cidade.Estado))]
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
