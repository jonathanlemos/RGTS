using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Pessoa")]
    public partial class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("CPF_CNPJ")]
        [StringLength(100)]
        public string CpfCnpj { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeCliente { get; set; }
        public int? IdTipo { get; set; }
        [StringLength(2)]
        public string SiglaEstado { get; set; }
        public string Endereco { get; set; }
        [StringLength(100)]
        public string Complemento { get; set; }
        [StringLength(100)]
        public string Numero { get; set; }
        [StringLength(100)]
        public string Bairro { get; set; }
        [StringLength(100)]
        public string Cidade { get; set; }
        [Column("CEP")]
        [StringLength(9)]
        public string Cep { get; set; }
        [StringLength(14)]
        public string Telefone1 { get; set; }
        [StringLength(14)]
        public string Telefone2 { get; set; }
        [StringLength(14)]
        public string Telefone3 { get; set; }
        [StringLength(15)]
        public string Celular1 { get; set; }
        [StringLength(15)]
        public string Celular2 { get; set; }
        [StringLength(15)]
        public string Celular3 { get; set; }
        [StringLength(18)]
        public string InscricaoEstadual { get; set; }
        [StringLength(12)]
        public string InscricaoMunicipal { get; set; }
        [Column("RG")]
        [StringLength(30)]
        public string Rg { get; set; }
        [StringLength(20)]
        public string OrgaoEmissor { get; set; }
        [StringLength(20)]
        public string Nacionalidade { get; set; }
        public int? EstadoCivil { get; set; }
        public int? RegimeCasamento { get; set; }
        [StringLength(100)]
        public string UsuarioInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
    }
}
