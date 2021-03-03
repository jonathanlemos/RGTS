using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Recebimento")]
    public partial class Recebimento
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdTipoRecebimento { get; set; }
        public int? IdNaturezaRecebimento { get; set; }
        public int? IdOrigemRecebimento { get; set; }
        public int? IdServicoCobranca { get; set; }
        public int? NumeroTransacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataRecebimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataRealizacaoBaixa { get; set; }
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
