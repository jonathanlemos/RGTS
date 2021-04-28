﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("DescricaoAlternativaRubrica")]
    public partial class DescricaoAlternativaRubrica
    {
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        [StringLength(50)]
        public string NomeDescricaAlternativa { get; set; }
        public int? IdRubrica { get; set; }
        [StringLength(100)]
        public string UsuarioInsercao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInsercao { get; set; }
        [StringLength(100)]
        public string UsuarioAlteracao { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataAlteracao { get; set; }
    }
}
