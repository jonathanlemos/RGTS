﻿using System;
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
        public Pessoa()
        {
            InverseUsuarioAlteracao = new HashSet<Pessoa>();
            InverseUsuarioInsercao = new HashSet<Pessoa>();
        }

        [Key]
        public int Id { get; set; }
        public int? TipoPessoa { get; set; }
        [StringLength(255)]
        public string Logradouro { get; set; }
        [StringLength(20)]
        public string Numero { get; set; }
        [StringLength(50)]
        public string Complemento { get; set; }
        [StringLength(50)]
        public string Bairro { get; set; }
        [Column("CEP")]
        [StringLength(9)]
        public string Cep { get; set; }
        [StringLength(15)]
        public string Telefone1 { get; set; }
        [StringLength(15)]
        public string Telefone2 { get; set; }
        [StringLength(15)]
        public string Telefone3 { get; set; }
        [StringLength(15)]
        public string Celular1 { get; set; }
        [StringLength(15)]
        public string Celular2 { get; set; }
        [StringLength(15)]
        public string Celular3 { get; set; }
        [Column("CPF_CNPJ")]
        [StringLength(100)]
        public string CpfCnpj { get; set; }
        [StringLength(100)]
        public string Marca { get; set; }
        [StringLength(100)]
        public string RazaoSocial { get; set; }
        [StringLength(100)]
        public string InscricaoEstadual { get; set; }
        [StringLength(100)]
        public string InscricaoMunicipal { get; set; }
        [Column("RG")]
        [StringLength(100)]
        public string Rg { get; set; }
        [StringLength(100)]
        public string OrgaoEmissor { get; set; }
        [StringLength(100)]
        public string Nacionalidade { get; set; }
        [StringLength(100)]
        public string EstadoCivil { get; set; }
        [StringLength(100)]
        public string RegimeCasamento { get; set; }
        public int? UsuarioInsercaoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        public int? UsuarioAlteracaoId { get; set; }
        [Required]
        [StringLength(30)]
        public string Senha { get; set; }
        [Required]
        public bool? Ativo { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        public int SexoId { get; set; }
        [Required]
        [StringLength(100)]
        public string PrimeiroNome { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [ForeignKey(nameof(Numero))]
        [InverseProperty(nameof(Telefone.Pessoas))]
        public virtual Telefone NumeroNavigation { get; set; }
        [ForeignKey(nameof(TipoPessoa))]
        [InverseProperty(nameof(Sexo.Pessoas))]
        public virtual Sexo TipoPessoaNavigation { get; set; }
        [ForeignKey(nameof(UsuarioAlteracaoId))]
        [InverseProperty(nameof(Pessoa.InverseUsuarioAlteracao))]
        public virtual Pessoa UsuarioAlteracao { get; set; }
        [ForeignKey(nameof(UsuarioInsercaoId))]
        [InverseProperty(nameof(Pessoa.InverseUsuarioInsercao))]
        public virtual Pessoa UsuarioInsercao { get; set; }
        [InverseProperty(nameof(Pessoa.UsuarioAlteracao))]
        public virtual ICollection<Pessoa> InverseUsuarioAlteracao { get; set; }
        [InverseProperty(nameof(Pessoa.UsuarioInsercao))]
        public virtual ICollection<Pessoa> InverseUsuarioInsercao { get; set; }
    }
}
