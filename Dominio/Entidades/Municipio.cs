using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Municipio")]
    public partial class Municipio
    {
        [Key]
        [StringLength(2)]
        public string SiglaEstado { get; set; }
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeMunicipio { get; set; }
    }
}
