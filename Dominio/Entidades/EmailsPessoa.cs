using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("EmailsPessoa")]
    public partial class EmailsPessoa
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("pessoa")]
        public int? IdPessoa { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        
        public virtual Pessoa pessoa { get; set; }
    }
}
