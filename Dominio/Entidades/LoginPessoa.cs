using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("LoginPessoa")]
    public partial class LoginPessoa
    {
        [Key]
        public int Id { get; set; }
        public int PessoaId { get; set; }
        [Required]
        [StringLength(50)]
        public string LoginAcesso { get; set; }
        [Required]
        [StringLength(300)]
        public string Senha { get; set; }
    }
}
