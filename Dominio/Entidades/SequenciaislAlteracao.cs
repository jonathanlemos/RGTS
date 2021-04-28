using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("SequenciaislAlteracao")]
    public partial class SequenciaislAlteracao
    {
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdInstrumentto { get; set; }
        public int? IdSeqAltContratoLocacao { get; set; }
        public int? IdSeqAltFaixasAluguel { get; set; }
        public int? IdSeqAltFaixasAluguelPercentual { get; set; }
        public int? IdSeqAltFaixasDesconto { get; set; }
        public int? IdSeqAltItensRubricaContrato { get; set; }
        public int? IdSeqAltPessoaPapelInstrumento { get; set; }
        public int? IdSeqAltFormulasContrato { get; set; }
        public int? IdSeqAltValoresFixos { get; set; }
        public int? IdSeqAltUnidade { get; set; }
        public int? IdSeqAltUnidadesContrato { get; set; }
        [Column("eAtivo")]
        public bool? EAtivo { get; set; }
    }
}
