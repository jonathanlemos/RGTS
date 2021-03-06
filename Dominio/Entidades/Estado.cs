﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Estado")]
    public partial class Estado
    {
        [Key]
        [StringLength(2)]
        public string SiglaEstado { get; set; }
        [StringLength(50)]
        public string NomeEstado { get; set; }
    }
}
