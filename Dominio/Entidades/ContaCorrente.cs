using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("ContaCorrente")]
    public partial class ContaCorrente
    {
        public ContaCorrente()
        {
        }

        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdServicoCobranca { get; set; }
        [ForeignKey("banco")]
        public int? IdBanco { get; set; }
        [StringLength(4)]
        public string Agencia { get; set; }
        [StringLength(1)]
        public string DvAgencia { get; set; }
        [StringLength(50)]
        public string NumeroContaCorrente { get; set; }
        [StringLength(1)]
        public string DvContaCorrente { get; set; }
        public int? CamaraCompensacao { get; set; }
        public int? IdPessoaTitular { get; set; }
        [StringLength(2)]
        public string OrdemPartilha { get; set; }
        [Column("eContaVinculada")]
        public bool? EContaVinculada { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }

        public virtual Banco banco { get; set; }

        public virtual ICollection<PartilhaBancarium> PartilhaBancaria { get; set; }

        public virtual ICollection<ServicoCobranca> servicoCobranca { get; set; }
    }
}
