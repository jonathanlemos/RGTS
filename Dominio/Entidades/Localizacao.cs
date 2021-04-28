using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("Localizacao")]
    public partial class Localizacao
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeLocalizacao { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInsercao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
