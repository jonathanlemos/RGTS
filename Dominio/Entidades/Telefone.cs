using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Telefone")]
    public partial class Telefone
    {
        [Required]
        [StringLength(20)]
        public string Id { get; set; }
        [Required]
        [StringLength(30)]
        public string TelefonePrincipal { get; set; }
        [StringLength(30)]
        public string Telefone1 { get; set; }
        [StringLength(30)]
        public string Telefone2 { get; set; }
        [StringLength(30)]
        public string Telefone3 { get; set; }
    }
}
