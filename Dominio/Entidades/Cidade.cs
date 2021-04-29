using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Dominio.Entidades
{
    [Table("Cidade")]
    public partial class Cidade
    {
        private readonly ILazyLoader _lazyLoader;

        //public Cidade()
        //{

        //}

        //public Cidade(ILazyLoader lazyLoader)
        //{
        //    _lazyLoader = lazyLoader;
        //}

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        public int EstadoId { get; set; }

        [ForeignKey(nameof(EstadoId))]
        [InverseProperty("Cidades")]
        public virtual Estado Estado { get; set; }
        //public Estado Estado
        //{
        //    get
        //    {
        //        if (EstadoCarregado == null)
        //            EstadoCarregado = new Estado();

        //        _lazyLoader.Load(this, ref EstadoCarregado);

        //        return EstadoCarregado;
        //    }
        //    set => EstadoCarregado = value;
        //}

        //private Estado EstadoCarregado;
    }
}
