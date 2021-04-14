using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Endereco")]
    public partial class Endereco
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Descricao { get; set; }
        [StringLength(10)]
        public string Complemento { get; set; }
        public int? Numero { get; set; }
        [StringLength(10)]
        public string Bairro { get; set; }
        [Column("CEP")]
        [StringLength(10)]
        public string Cep { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        [StringLength(10)]
        public string Pais { get; set; }
        [Required]
        public bool? Principal { get; set; }
        public int PessoaId { get; set; }
    }
}
