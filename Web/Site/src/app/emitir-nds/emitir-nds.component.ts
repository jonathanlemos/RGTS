import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
  selector: 'app-emitir-nds',
  templateUrl: './emitir-nds.component.html',
  styleUrls: ['./emitir-nds.component.css']
})
export class EmitirNdsComponent implements OnInit {
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
    this.tipoLocacaoSelecionada = 1;
    this.CarregarTipoInstrumento();
    this.CarregarMarcas();
    this.CarregarUnidades();
  }

  CarregarUnidades() {
    this.lucService.getAll().subscribe(
      (luc: Luc[]) => {
        this.lucs = luc;
      },
      (erro: any) => {
        console.log("Erro ao carregar as unidades. Erro: " + erro);
      }
    );
  }
  CarregarMarcas() {
    this.marcaService.getAll().subscribe(
      (marca: Marca[]) => {
        this.marcas = marca;
      },
      (erro: any) => {
        console.log("Erro ao carregar as marcas. Erro: " + erro);
      }
    );
  }
  CarregarTipoInstrumento() {
    this.tipoInstrumentoService.getAll().subscribe(
      (tipoInstrumeto: TipoInstrumento[]) => {
        this.tiposLocacoes = tipoInstrumeto;
      },
      (erro: any) => {
        console.log("Erro ao carregar os tipos de instrumento. Erro: " + erro);
      }
    );
  }

  PesquisarNDs() {
    this.ndsSelecionadas = [];

    this.nDFiltro.tipoLocacaoFiltro = this.tipoLocacaoSelecionada;
    this.nDFiltro.lucsFiltro = !!this.lucSelecionada ? this.lucSelecionada : [];
    this.nDFiltro.marcasFiltro = !!this.marcaSelecionada ? this.marcaSelecionada : [];
    this.nDFiltro.vencimentoNDFiltroDe = !!this.vencimentoDe ? new Date(this.vencimentoDe) : new Date(1901, 1, 1);
    this.nDFiltro.vencimentoNDFiltroAte = !!this.vencimentoAte ? new Date(this.vencimentoAte) : new Date(1901, 1, 1);

    this.nDService.filter(this.nDFiltro).toPromise().then(dados => {
      let retorno: ND[];

      retorno = dados;

      retorno.forEach((ret, index) => {
        ret.luc = new Luc();
        let dataBanco: any;
        dataBanco = ret.vencimento;
        ret.idShopping = Number(this.localStorageService.GetShoppingAtivo());
        ret.vencimento = new Date(dataBanco);
        ret.nomeSerie = this.series[ret.idSerie];
        ret.idSerie = ret.idSerie;
        this.contratoLucsService.getLucIdByInstrumentoId(ret.idInstrumento).toPromise().then(dados => {
          let contratoLucs = new ContratoLucs;
          contratoLucs = dados;
          Object.assign(ret.luc, this.lucs.filter(l => l.id == contratoLucs.idLuc)[0]);
        }).then(dados => {
          this.contratoLocacaoService.getIdInstrumento(ret.idInstrumento).subscribe((contratoLocacao: ContratoLocacao) => {
            ret.marca = new Marca();
            Object.assign(ret.marca, this.marcas.filter(r => r.id == contratoLocacao.idMarca)[0]);
          });
        });
      });
      this.nds = retorno;
    });
  }
  EmitirNds() {
    if (this.ndsSelecionadas.length == 0 || !this.ndsSelecionadas)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Selecione ao menos um valor para enviar emitir.' });
    else {
      this.nDService.visualizarNds(this.ndsSelecionadas.map(n => n.id));
    }
  }
}
