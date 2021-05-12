using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Banco")]
    public partial class Banco
    {
        public Banco()
        {
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string NomeBanco { get; set; }
        public int? NumeroBanco { get; set; }
        [StringLength(1)]
        public string DvBanco { get; set; }
        [StringLength(100)]
        public string Usuario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }

        public virtual ICollection<ContaCorrente> ContaCorrentes { get; set; }
    }
}
