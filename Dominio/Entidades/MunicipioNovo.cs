using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Municipio_novo")]
    public partial class MunicipioNovo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        [Column("Estado_id")]
        public int? EstadoId { get; set; }

        [ForeignKey(nameof(EstadoId))]
        [InverseProperty(nameof(EstadoNovo.MunicipioNovos))]
        public virtual EstadoNovo Estado { get; set; }
    }
}
