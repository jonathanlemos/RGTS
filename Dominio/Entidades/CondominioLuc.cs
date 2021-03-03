using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("CondominioLuc")]
    public partial class CondominioLuc
    {
        [Key]
        public int Id { get; set; }
        public int? IdLuc { get; set; }
        public int? IdCondominio { get; set; }
        public bool? ParticipaRateio { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
