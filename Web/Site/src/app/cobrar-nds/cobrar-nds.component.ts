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

@Component({
  selector: 'app-cobrar-nds',
  templateUrl: './cobrar-nds.component.html',
  styleUrls: ['./cobrar-nds.component.css']
})
export class CobrarNdsComponent implements OnInit {
  //Filtro
  tiposLocacoes: TipoInstrumento[];
  tipoLocacaoSelecionada: any;
  mensagemBoletoSelecionada: MensagemBoleto = new MensagemBoleto();
  instrucaoBoletoSelecionada: InstrucaoBoleto = new InstrucaoBoleto();
  servicoCobrancaSelecionado: ServicoCobranca = new ServicoCobranca();
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

  //Grid
  nds: ND[];
  ndsSelecionadas: ND[];
  contratoLucs: ContratoLucs = new ContratoLucs();

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
    this.carregarServicos();
    this.carregarMensagens();
    this.carregarInstrucoes();
    this.tipoLocacaoSelecionada = 1;
    this.CarregarTipoInstrumento();
    this.CarregarMarcas();
    this.CarregarUnidades();
  }

  carregarServicos() {
    this.servicoCobrancaService.getAll().subscribe((servicos: ServicoCobranca[]) => {
      this.servicosCobranca = servicos;
    });
  }

  carregarMensagens() {

  }

  carregarInstrucoes() {

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
  GerarArquivoRemessa() {

    if (this.ndsSelecionadas.length == 0 || !this.ndsSelecionadas)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Selecione ao menos um valor para enviar à cobrança.' });
    else if (!this.servicoCobrancaSelecionado)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Selecione o serviço de cobrança.' });
    else {
      this.nDService.gerarArquivoRemessa(this.servicoCobrancaSelecionado.id, !this.mensagemBoletoSelecionada.id ? 0 : this.mensagemBoletoSelecionada.id, !this.instrucaoBoletoSelecionada.id ? 0 : this.instrucaoBoletoSelecionada.id, this.ndsSelecionadas).subscribe(
        success => {
          saveAs(success.file, success.filename);
        },
        err => {
          alert("Ocorreu um erro no servidor ao fazer o Download do arquivo.");
        }
      );
    }
  }
}
