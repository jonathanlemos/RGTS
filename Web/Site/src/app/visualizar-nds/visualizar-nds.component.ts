import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { SelectItem, PrimeNGConfig, Confirmation, MessageService, ConfirmationService } from "primeng/api";
import { Luc } from '../Models/Luc';
import { Marca } from '../Models/Marca';
import { ND } from '../Models/ND';
import { TipoInstrumento } from '../Models/TipoInstrumento';
import { LocalStorageService } from '../Servicos/LocalStorage/local-storage.service';
import { LucService } from '../Servicos/Luc/luc.service';
import { MarcaService } from '../Servicos/Marca/marca.service';
import { ServicoCobrancaService } from '../Servicos/ServicoCobranca/servico-cobranca-service';
import { NDService } from '../Servicos/ND/ndservice'
import { Serie } from '../Enums/Serie';
import { ContratoLucsService } from '../Servicos/ContratoLucs/contratoLucs.service';
import { ContratoLocacaoService } from '../Servicos/ContratoLocacao/contratoLocacao.service'
import { ContratoLucs } from '../Models/contrato-lucs';
import { ContratoLocacao } from '../Models/contrato-locacao'
import { ServicoCobranca } from '../Models/ServicoCobranca';
import { InstrucaoBoleto } from '../Models/InstrucaoBoleto';
import { MensagemBoleto } from '../Models/MensagemBoleto';
import { TipoInstrumentoService } from '../Servicos/TipoInstrumento/tipo-instrumento.service';
import { Observable } from 'rxjs';
import { saveAs } from 'file-saver';
import { map } from "rxjs/operators";
import { Subject } from 'rxjs';
import { GrupoRubrica } from '../Models/grupoRubrica';

@Component({
  selector: 'app-visualizar-nds',
  templateUrl: './visualizar-nds.component.html',
  styleUrls: ['./visualizar-nds.component.css']
})
export class VisualizarNdsComponent implements OnInit {
  //Filtro
  tiposLocacoes: TipoInstrumento[];
  tipoLocacaoSelecionada: any;
  mensagensBoleto: MensagemBoleto[];
  instrucoesBoleto: InstrucaoBoleto[];
  servicosCobranca: ServicoCobranca[];
  lucs: any[];
  marcas: any[];
  lucSelecionada: any;
  marcaSelecionada: any;
  vencimentoDe: string;
  vencimentoAte: string;
  nDFiltro: ND = new ND()
  series = Serie;
  aceite: string;
  especie: string;
  display: boolean = false;

  //Grid
  nds: ND[];
  ndsSelecionadas: ND[];
  resultadoNds: any;
  contratoLucs: ContratoLucs = new ContratoLucs();
  grupoRubrica: GrupoRubrica[] = [];
  grupoRubricaNd: GrupoRubrica[] = [];
  grupoCND: boolean = false;
  grupoAMM: boolean = false;
  grupoFPP: boolean = false;

  dataEmissao: Date;
  dataLimite: Date;
  mensagens: string;
  instrucoes: string;
  dataDocumento: Date;
  especieDocumento: string;
  dataProcessamento: Date;
  codigoBarras: string[];
  modalBoletos: boolean = false;

  constructor(private primeNGConfig: PrimeNGConfig, private fb: FormBuilder,
    private nDService: NDService,
    private messageService: MessageService,
    private localStorageService: LocalStorageService,
    private confirmationService: ConfirmationService,
    private contratoLucsService: ContratoLucsService,
    private contratoLocacaoService: ContratoLocacaoService,
    private servicoCobrancaService: ServicoCobrancaService,
    private lucService: LucService,
    private marcaService: MarcaService,
    private tipoInstrumentoService: TipoInstrumentoService,
    private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this._route.queryParams.subscribe(result => {

      let nds: number[] = [];

      nds = result.dados;

      this.nDService.gerarBoletos(nds).subscribe(dados => {
        this.resultadoNds = dados;
      });
    });
  }

  filtroGruposNd(ndId: number) {

    let _nd: any;

    _nd = this.resultadoNds.filter(t => t.id == ndId);

    this.grupoRubricaNd = [];

    if (_nd[0].itensNds.filter(i => i.rubrica.idGrupoRubrica == 1).length > 0)
      this.grupoRubricaNd.push({
        id: 1,
        nomeGrupo: "ALUGUEL"
      });
    if (_nd[0].itensNds.filter(i => i.rubrica.idGrupoRubrica == 2).length > 0)
      this.grupoRubrica.push({
        id: 2,
        nomeGrupo: "CONDOMÍNIO"
      });
    if (_nd[0].itensNds.filter(i => i.rubrica.idGrupoRubrica == 3).length > 0)
      this.grupoRubrica.push({
        id: 3,
        nomeGrupo: "FUNDO DE PROMOÇÃO"
      });

    return this.grupoRubricaNd;
  }

  getArrayCB(ndId: number) {

    let _nd: any;

    _nd = this.resultadoNds.filter(t => t.id == ndId);

    let arr: string[] = [];

    arr = [..._nd[0].codigoBarras];

    return arr;
  }
  imprimir() {
    window.print();
  }
}
