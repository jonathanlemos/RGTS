using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("ContaCorrente")]
    public partial class ContaCorrente
    {
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdBanco { get; set; }
        [StringLength(4)]
        public string Agencia { get; set; }
        [StringLength(1)]
        public string DvAgencia { get; set; }
        [Column("ContaCorrente")]
        public int? ContaCorrente1 { get; set; }
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
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
