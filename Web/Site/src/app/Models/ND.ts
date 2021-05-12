import { Luc } from './Luc';
import { Marca } from './Marca';
import { ItensND } from './ItensND'
import { ServicoCobranca } from './ServicoCobranca'
import { Pessoa } from './Pessoa'

export class ND {
  id: number | undefined;
  idShopping: number | undefined;
  idInstrumento: number | undefined;
  idServicoCobranca: number | undefined;
  valorOriginal: number | undefined;
  valorPrincipal: number | undefined;
  valorSaldo: number | undefined;
  vencimento: Date | undefined;
  idLiquidacao: number | undefined;
  idCobranca: number | undefined;
  liquidacao: number | undefined;
  percentualMulta: number | undefined;
  idTipoJuros: number | undefined;
  percentualJuros: number | undefined;
  pessoaBeneficiario: number | undefined;
  pessoaPagador: number | undefined;
  nossoNumero: string | undefined;
  digitoNossoNumero: string | undefined;
  arquivoRemessa: string | undefined;
  geracaoArquivoRemessa: Date | undefined;
  arquivoRetorno: string | undefined;
  tratamentoArquivoRetorno: Date | undefined;
  idFormaCriacao: number | undefined;
  remessa: number | undefined;
  idInclusao: number | undefined;
  usuario: string | undefined;
  dataInsercao: Date | undefined;
  usuarioAlteracao: string | undefined;
  dataAlteracao: Date | undefined;
  mesProcessamento: number | undefined;
  anoProcessamento: number | undefined;
  idSerie: number | undefined;
  nomeSerie: string | undefined;
  luc: Luc;
  marca: Marca;
  itensNd: ItensND[];
  tipoLocacaoFiltro: number | undefined;
  lucsFiltro: any[];
  marcasFiltro: any[];
  vencimentoNDFiltroDe: Date | undefined;
  vencimentoNDFiltroAte: Date | undefined;
  servicoCobranca: ServicoCobranca;
  pagador: Pessoa;
  beneficiario: Pessoa;
  codigoBarras: string;
}
