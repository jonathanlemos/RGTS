using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Estado_novo")]
    public partial class EstadoNovo
    {
        public EstadoNovo()
        {
            Cidades = new HashSet<Cidade>();
            MunicipioNovos = new HashSet<MunicipioNovo>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }

        [InverseProperty(nameof(Cidade.Estado))]
        public virtual ICollection<Cidade> Cidades { get; set; }
        [InverseProperty(nameof(MunicipioNovo.Estado))]
        public virtual ICollection<MunicipioNovo> MunicipioNovos { get; set; }
    }
}
