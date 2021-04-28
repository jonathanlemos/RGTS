using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Sexo")]
    public partial class Sexo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Descricao { get; set; }
    }
}
