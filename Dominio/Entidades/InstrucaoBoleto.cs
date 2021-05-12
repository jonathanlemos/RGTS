using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("InstrucaoBoleto")]
    public partial class InstrucaoBoleto
    {
        [Key]
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        [StringLength(50)]
        public string NomeInstrucao { get; set; }
        [StringLength(65)]
        public string Instrucao1 { get; set; }
        [StringLength(65)]
        public string Instrucao2 { get; set; }
        [StringLength(65)]
        public string Instrucao3 { get; set; }
        [StringLength(65)]
        public string Instrucao4 { get; set; }
        [StringLength(65)]
        public string Instrucao5 { get; set; }
        [StringLength(65)]
        public string Instrucao6 { get; set; }
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
