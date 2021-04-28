using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Estado")]
    public partial class Estado
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }
        public int Regiao { get; set; }
    }
}
