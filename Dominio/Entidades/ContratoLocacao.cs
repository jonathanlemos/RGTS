using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.Entidades
{
    [Keyless]
    [Table("ContratoLocacao")]
    public partial class ContratoLocacao
    {
        public int Id { get; set; }
        public int? IdShopping { get; set; }
        public int? IdInstrumento { get; set; }
        public int? IdMarca { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataInicioVigencia { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataFimVigencia { get; set; }
        public int? IdFormaCorrecao { get; set; }
        public int? IdTipoJuros { get; set; }
        public int? IdTipoContrato { get; set; }
        public int? IdPrazoContrato { get; set; }
        public int? IdEmpreendimento { get; set; }
        public string Observacao { get; set; }
        public int? IdIndicador { get; set; }
        [Column(TypeName = "decimal(17, 2)")]
        public decimal? PercentualMulta { get; set; }
        [Column(TypeName = "decimal(17, 2)")]
        public decimal? PercentualJuros { get; set; }
        public int? IdPeriodicidadeReajuste { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataBaseReajuste { get; set; }
        [Column("eDeclaraVenda")]
        public bool? EDeclaraVenda { get; set; }
        [Column("eDeclaraVendaAuditada")]
        public bool? EDeclaraVendaAuditada { get; set; }
        public int? IdFormaCalculoAluguel { get; set; }
        public int? IdTipoReajusteAluguel { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataInicioCarenciaAluguel { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataFimCarenciaAluguel { get; set; }
        public int? IdItemRubricaAluguel { get; set; }
        public int? IdItemRubricaDescontoAluguel { get; set; }
        public int? IdItemRubricaCondominio { get; set; }
        [Column("CRD", TypeName = "decimal(12, 4)")]
        public decimal? Crd { get; set; }
        [Column("FancoilTR", TypeName = "decimal(12, 4)")]
        public decimal? FancoilTr { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataInicioCarenciaCondominio { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? DataFimCarenciaCondominio { get; set; }
        [StringLength(10)]
        public string IdItemRubricaAluguelPercentual { get; set; }
        public int? IdItemRubricaDescontoAluguelPercentual { get; set; }
        public int? IdTipoVendaInformada { get; set; }
        public int? IdTipoVendaCalculo { get; set; }
        public int? IdPeriodicidadeInformativoVenda { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataInicioCarenciaAluguelPercentual { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataFimCarenciaAluguelPercentual { get; set; }
        public int? IdMesCompetenciaAluguelAntecipado { get; set; }
        public int? IdVencimentoAluguelAntecipado { get; set; }
        public int? IdItemRubricaCotaOrdinaria { get; set; }
        public int? IdItemRubricaCotaExtraordinaria { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataInicioCarenciaFundo { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataFimCarenciaFundo { get; set; }
        [Column("ePercentualSobreAMMLiquido")]
        public bool? EPercentualSobreAmmliquido { get; set; }
        [Column("ePercenutalSobreAMMBruto")]
        public bool? EPercenutalSobreAmmbruto { get; set; }
        [Column("ePercentualSobreAluguelPercentual")]
        public bool? EPercentualSobreAluguelPercentual { get; set; }
        [Column("eAtivo")]
        public bool? EAtivo { get; set; }
        [Column("eEmpreendedor")]
        public bool? EEmpreendedor { get; set; }
    }
}
