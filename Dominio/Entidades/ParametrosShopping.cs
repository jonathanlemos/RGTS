using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("ParametrosShopping")]
    public partial class ParametrosShopping
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeShopping { get; set; }
        [StringLength(100)]
        public string Logo { get; set; }
        public int? AnoProcessamento { get; set; }
        public int? MesProcessamento { get; set; }
        public int? AnoAtual { get; set; }
        public int? MesAtual { get; set; }
        public string Endereco { get; set; }
        [StringLength(9)]
        public string Cep { get; set; }
        [StringLength(100)]
        public string Numero { get; set; }
        [StringLength(2)]
        public string SiglaEstado { get; set; }
        [StringLength(10)]
        public string SiglaShopping { get; set; }
        [StringLength(100)]
        public string LogoAdm { get; set; }
        public int? IdPessoaAdm { get; set; }
        [Column("eConsolidadorVendaMensal")]
        public bool? EConsolidadorVendaMensal { get; set; }
        public int? IdTipoJuros { get; set; }
        public int? IdTipoCorrecao { get; set; }
        public int? IdFormaCorrecao { get; set; }
        [Column("eMesComercial")]
        public bool? EMesComercial { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataInauguracao { get; set; }
        [StringLength(100)]
        public string UsuarioInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [StringLength(100)]
        public string UsuarioAltecao { get; set; }
    }
}
