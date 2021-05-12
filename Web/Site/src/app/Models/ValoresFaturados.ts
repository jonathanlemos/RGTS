import { Luc } from './Luc';
import { Marca } from './Marca';
import { ContratoLocacao } from './contrato-locacao';
import { Rubrica } from './Rubrica';

export class ValoresFaturados {
  id: number | undefined;
  idShopping: number | undefined;
  idNd: number | undefined;
  idItemND: number | undefined;
  idRubrica: number | undefined;
  mesCompetencia: number | undefined;
  anoCompetencia: number | undefined;
  mesProcessamento: number | undefined;
  anoProcessamento: number | undefined;
  valorCalculado: number | undefined;
  valorFaturado: number | undefined;
  vencimentoNd: Date | undefined;
  idSerie: number | undefined;
  nomeSerie: String | undefined;
  eAprovado: Boolean | undefined;
  documento: string | undefined;
  idRemessa: number | undefined;
  idSeqAltContratoLocacao: number | undefined;
  idInstrumento: number | undefined;
  idDescricaoAlternativa: number | undefined;
  luc: Luc;
  marca: Marca;
  rubrica: Rubrica;
  enviados: boolean | undefined;
  tipoLocacaoFiltro: number | undefined;
  anoMesProcessamentoFiltroDe: number | undefined;
  anoMesProcessamentoFiltroAte: number | undefined;
  lucsFiltro: any[];
  marcasFiltro: any[];
  vencimentoNDFiltroDe: Date | undefined;
  vencimentoNDFiltroAte: Date | undefined;
}
