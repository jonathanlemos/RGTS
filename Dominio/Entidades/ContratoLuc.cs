﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    public partial class ContratoLuc
    {
        public int Id { get; set; }
        public int? IdInstrumento { get; set; }
        public int? IdLuc { get; set; }
        [Column("eUnidadePrincipal")]
        public bool? EUnidadePrincipal { get; set; }
    }
}