using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("ServicoCobranca")]
    public partial class ServicoCobranca
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string NomeServico { get; set; }
        public int? IdBanco { get; set; }
        public int? IdContaCorrente { get; set; }
        [StringLength(3)]
        public string Carteira { get; set; }
        [StringLength(16)]
        public string Convenio { get; set; }
        [StringLength(3)]
        public string Variacao { get; set; }
        [StringLength(20)]
        public string PrefixoArquivoRemessa { get; set; }
        [StringLength(2)]
        public string SequencialArquivoRemessa { get; set; }
        [StringLength(3)]
        public string ExtensaoArquivoRemessa { get; set; }
        [StringLength(5)]
        public string PrefixoArquivoRetorno { get; set; }
        [StringLength(2)]
        public string SequencialArquivoRetorno { get; set; }
        [StringLength(3)]
        public string ExtensaoArquivoRetorno { get; set; }
        public int? IdTipoEmissao { get; set; }
        public int? IdTipoServicoCobranca { get; set; }
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
