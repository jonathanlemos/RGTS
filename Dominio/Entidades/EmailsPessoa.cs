using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("EmailsPessoa")]
    public partial class EmailsPessoa
    {
        public int Id { get; set; }
        public int? IdPessoa { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
    }
}
