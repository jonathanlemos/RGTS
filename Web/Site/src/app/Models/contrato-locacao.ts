export class ContratoLocacao {
    id: number;
    idShopping: number | undefined;
    idMarca: number | undefined; 
    dataInicioVigencia: Date | undefined;
    dataFimVigencia: Date | undefined;
    idFormaCorrecao: number | undefined;
    idTipoJuros: number | undefined;
    idTipoContrato: number | undefined;
    idPrazoContrato: number | undefined;
    idEmpreendimento: number | undefined;
    observacao: string | undefined;
    idIndicador: number | undefined;
    percentualMulta: number | undefined;
    percentualJuros: number | undefined;
    idPeriodicidadeReajuste: number | undefined;
    dataBaseReajuste: Date | undefined;
    eDeclaraVenda: boolean | undefined;
    eDeclaraVendaAuditada: boolean | undefined;
    idFormaCalculoAluguel: number | undefined;
    idTipoReajusteAluguel: string | undefined;
    dataInicioCarenciaAluguel: number | undefined;
    dataFimCarenciaAluguel: number | undefined;
    idItemRubricaAluguel: number | undefined;
    idItemRubricaDescontoAluguel: number | undefined;
    idItemRubricaCondominio: number | undefined;
    crd: number | undefined;
    fancoilTR: string | undefined;
    dataInicioCarenciaCondominio: Date | undefined;
    dataFimCarenciaCondominio: Date | undefined;
    idItemRubricaAluguelPercentual: string | undefined;
    idItemRubricaDescontoAluguelPercentual: number | undefined;
    idTipoVendaInformada: number;
    idTipoVendaCalculo: number | undefined;
    idPeriodicidadeInformativoVenda: number | undefined; 
    dataInicioCarenciaAluguelPercentual: Date | undefined;
    dataFimCarenciaAluguelPercentual: Date | undefined;
    idMesCompetenciaAluguelAntecipado: number | undefined;
    idVencimentoAluguelAntecipado: number | undefined;
    idItemRubricaCotaOrdinaria: number | undefined;
    idItemRubricaCotaExtraordinaria: number | undefined;
    dataInicioCarenciaFundo: Date | undefined;
    dataFimCarenciaFundo: Date | undefined;
    ePercentualSobreAMMLiquido: boolean | undefined;
    ePercenutalSobreAMMBruto: boolean | undefined;
    ePercentualSobreAluguelPercentual: boolean | undefined;
    eAtivo: boolean | undefined;
}