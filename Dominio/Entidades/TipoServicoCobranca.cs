using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("TipoServicoCobranca")]
    public partial class TipoServicoCobranca
    {
        public TipoServicoCobranca()
        {
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeTipoServicoCobranca { get; set; }
        [Column("ePartilhado")]
        public bool? ePartilhado { get; set; }

        //public virtual ICollection<ServicoCobranca> servicoCobranca { get; set; }
    }
}
