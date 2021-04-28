using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("sysdiagrams")]
    public partial class Sysdiagram
    {
        [Column("name", TypeName = "date")]
        public DateTime Name { get; set; }
        [Column("principal_id")]
        public int PrincipalId { get; set; }
        [Column("diagram_id")]
        public int DiagramId { get; set; }
        [Column("version")]
        public int? Version { get; set; }
        [Column("definition")]
        public byte[] Definition { get; set; }
    }
}
