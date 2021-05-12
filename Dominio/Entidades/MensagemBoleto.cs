using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("MensagemBoleto")]
    public partial class MensagemBoleto
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        [StringLength(50)]
        public string NomeMensagem { get; set; }
        [StringLength(65)]
        public string Mensagem1 { get; set; }
        [StringLength(65)]
        public string Mensagem2 { get; set; }
        [StringLength(65)]
        public string Mensagem3 { get; set; }
        [StringLength(65)]
        public string Mensagem4 { get; set; }
        [StringLength(65)]
        public string Mensagem5 { get; set; }
        [StringLength(65)]
        public string Mensagem6 { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
