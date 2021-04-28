using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("LoginPessoa")]
    public partial class LoginPessoa
    {
        public int Id { get; set; }
        [Required]
        public int PessoaId { get; set; }
        [Required]
        [StringLength(50)]        
        public string LoginAcesso { get; set; }
        [Required]
        [StringLength(300)]
        public string Senha { get; set; }

    }
}
