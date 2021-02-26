using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Cidade")]
    public class ContratoLocacao
    {
        [Column("Id", TypeName = "int")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("IdShopping", TypeName = "int")]
        public int IdShopping { get; set; }

        [Column("IdInstrumento", TypeName = "int")]
        public int IdInstrumento { get; set; }

        [Column("IdMarca", TypeName = "int")]
        public int IdMarca { get; set; }

        [Column("DataInicioVigencia", TypeName = "DateTime")]
        public DateTime DataInicioVigencia { get; set; }

        [Column("DataFimVigencia", TypeName = "DateTime")]
        public DateTime DataFimVigencia { get; set; }

        [Column("IdFormaCorrecao", TypeName = "int")]
        public int IdFormaCorrecao { get; set; }

        [Column("IdTipoJuros", TypeName = "int")]
        public int IdTipoJuros { get; set; }

        [Column("IdTipoContrato", TypeName = "int")]
        public int IdTipoContrato { get; set; }

        [Column("IdPrazoContrato", TypeName = "int")]
        public int IdPrazoContrato { get; set; }

        [Column("IdEmpreendimento", TypeName = "int")]
        public int IdEmpreendimento { get; set; }

        [Column("Observacao", TypeName = "varchar")]
        public string Observacao { get; set; }

        [Column("IdIndicador", TypeName = "int")]
        public int IdIndicador { get; set; }

        [Column("PercentualMulta", TypeName = "numeric")]
        [Range(2, 17, ErrorMessage = "Erro no range.")]
        public double PercentualMulta { get; set; }

        [Column("PercentualJuros", TypeName = "numeric")]
        [Range(2, 17, ErrorMessage = "Erro no range.")]
        public double PercentualJuros { get; set; }

        [Column("IdPeriodicidadeReajuste", TypeName = "int")]
        public int IdPeriodicidadeReajuste { get; set; }

        [Column("DataBaseReajuste", TypeName = "DateTime")]
        public DateTime DataBaseReajuste { get; set; }

        [Column("eDeclaraVenda", TypeName = "bit")]
        public bool eDeclaraVenda { get; set; }

        [Column("eDeclaraVendaAuditada", TypeName = "bit")]
        public bool eDeclaraVendaAuditada { get; set; }

        [Column("IdFormaCalculoAluguel", TypeName = "int")]
        public int IdFormaCalculoAluguel { get; set; }

        [Column("IdTipoReajusteAluguel", TypeName = "int")]
        public int IdTipoReajusteAluguel { get; set; }

        [Column("DataInicioCarenciaAluguel", TypeName = "DateTime")]
        public DateTime DataInicioCarenciaAluguel { get; set; }

        [Column("DataFimCarenciaAluguel", TypeName = "DateTime")]
        public DateTime DataFimCarenciaAluguel { get; set; }

        [Column("IdItemRubricaAluguel", TypeName = "int")]
        public int IdItemRubricaAluguel { get; set; }

        [Column("IdItemRubricaDescontoAluguel", TypeName = "int")]
        public int IdItemRubricaDescontoAluguel { get; set; }

        [Column("IdItemRubricaCondominio", TypeName = "int")]
        public int IdItemRubricaCondominio { get; set; }

        [Column("CRD", TypeName = "numeric")]
        [Range(4,12, ErrorMessage = "Erro no range.")]
        public double CRD { get; set; }

        [Column("FancoilTR", TypeName = "numeric")]
        [Range(4, 12, ErrorMessage = "Erro no range.")]
        public int FancoilTR { get; set; }

        [Column("DataInicioCarenciaCondominio", TypeName = "DateTime")]
        public DateTime DataInicioCarenciaCondominio { get; set; }

        [Column("DataFimCarenciaCondominio", TypeName = "DateTime")]
        public DateTime DataFimCarenciaCondominio { get; set; }

        [Column("IdItemRubricaAluguelPercentual", TypeName = "int")]
        public int IdItemRubricaAluguelPercentual { get; set; }

        [Column("IdItemRubricaDescontoAluguelPercentual", TypeName = "int")]
        public int IdItemRubricaDescontoAluguelPercentual { get; set; }

        [Column("IdTipoVendaInformada", TypeName = "int")]
        public int IdTipoVendaInformada { get; set; }

        [Column("IdTipoVendaCalculo", TypeName = "int")]
        public int IdTipoVendaCalculo { get; set; }

        [Column("IdPeriodicidadeInformativoVenda", TypeName = "int")]
        public int IdPeriodicidadeInformativoVenda { get; set; }

        [Column("DataInicioCarenciaAluguelPercentual", TypeName = "DateTime")]
        public DateTime DataInicioCarenciaAluguelPercentual { get; set; }

        [Column("DataFimCarenciaAluguelPercentual", TypeName = "DateTime")]
        public DateTime DataFimCarenciaAluguelPercentual { get; set; }

        [Column("IdMesCompetenciaAluguelAntecipado", TypeName = "int")]
        public int IdMesCompetenciaAluguelAntecipado { get; set; }

        [Column("IdVencimentoAluguelAntecipado", TypeName = "int")]
        public int IdVencimentoAluguelAntecipado { get; set; }

        [Column("IdItemRubricaCotaOrdinaria", TypeName = "int")]
        public int IdItemRubricaCotaOrdinaria { get; set; }

        [Column("IdItemRubricaCotaExtraordinaria", TypeName = "int")]
        public int IdItemRubricaCotaExtraordinaria { get; set; }

        [Column("DataInicioCarenciaFundo", TypeName = "DateTime")]
        public DateTime DataInicioCarenciaFundo { get; set; }

        [Column("IdMesCompetencDataFimCarenciaFundoiaAluguelAntecipado", TypeName = "DateTime")]
        public DateTime DataFimCarenciaFundo { get; set; }

        [Column("ePercentualSobreAMMLiquido", TypeName = "bit")]
        public bool ePercentualSobreAMMLiquido { get; set; }

        [Column("ePercenutalSobreAMMBruto", TypeName = "bit")]
        public bool ePercenutalSobreAMMBruto { get; set; }

        [Column("ePercentualSobreAluguelPercentual", TypeName = "bit")]
        public bool ePercentualSobreAluguelPercentual { get; set; }

        [Column("eAtivo", TypeName = "bit")]
        public bool eAtivo { get; set; }
    }
}

