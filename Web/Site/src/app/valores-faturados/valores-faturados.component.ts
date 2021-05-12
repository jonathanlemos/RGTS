import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, BaseRouteReuseStrategy } from '@angular/router'
import { LocalStorageService } from '../Servicos/LocalStorage/local-storage.service';
import {
  trigger,
  state,
  style,
  transition,
  animate
} from "@angular/animations";

//models
import { ValoresFaturados } from '../Models/ValoresFaturados';

//services
import { ValoresFaturadosService } from '../Servicos/ValoresFaturados/valoresfaturados.service';

//exportar excel/pdf
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

//primeng
//import { MultiSelectModule } from 'primeng/multiselect';
//import { Table } from 'primeng/table';

import { SelectItem, PrimeNGConfig, Confirmation } from "primeng/api";
import { Luc } from '../Models/Luc';
import { Marca } from '../Models/Marca';
import { TipoInstrumento } from '../Models/TipoInstrumento';
import { LucService } from '../Servicos/Luc/luc.service';
import { MarcaService } from '../Servicos/Marca/marca.service';

import { TipoInstrumentoService } from '../Servicos/TipoInstrumento/tipo-instrumento.service';
import { ContratoLucsService } from '../Servicos/ContratoLucs/contratoLucs.service';
import { RubricaService } from '../Servicos/Rubrica/rubrica.service';
import { ContratoService } from '../Servicos/Contrato/contrato.service';
import { InputMaskModule } from 'primeng/inputmask';
import { Rubrica } from '../Models/rubrica';
import { ContratoLucs } from '../Models/contrato-lucs';
import { Contrato } from '../Models/Contrato';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Serie } from '../Enums/Serie';
import { ContratoLocacaoService } from '../Servicos/ContratoLocacao/contratoLocacao.service';
import { ContratoLocacao } from '../Models/contrato-locacao';
import { element } from 'protractor';

@Component({
  selector: 'app-valores-faturados.component',
  templateUrl: './valores-faturados.component.html',
  styleUrls: ['./valores-faturados.component.css'],
  providers: [MessageService, ConfirmationService]
})

export class ValoresFaturadosComponent implements OnInit {

  luc: Luc = new Luc();
  marca: Marca = new Marca();
  rubrica: Rubrica = new Rubrica();
  tipoInstrumento: TipoInstrumento = new TipoInstrumento();
  contratoLucs: ContratoLucs = new ContratoLucs();
  valorFaturadoFiltro: ValoresFaturados = new ValoresFaturados()
  valorFaturadoEdicao: ValoresFaturados;
  series = Serie;
  //Grid
  valoresFaturados: ValoresFaturados[];
  valoresFaturadosSelecionados: ValoresFaturados[];

  //Pesquisa
  tipoLocacaoSelecionada: any;
  lucSelecionada: any;
  marcaSelecionada: any;
  tiposLocacoes: any[];
  lucs: any[];
  marcas: any[];
  rubricas: any[];
  valmesAnoProcDe: string;
  valmesAnoProcAte: string;
  vencimentoDe: string;
  vencimentoAte: string;
  MesAnoProcessamento: string;
  statusCobranca: any;

  submitted: boolean;
  ModalValoresFaturados: boolean;
  ModalValoresFaturadosEdicao: boolean;

  //Campos Modal
  lucSelecionadaModal: any;
  rubricaSelecionadaModal: any;
  TituloModal: string;
  competenciaModal: string;
  vencimentoModal: Date;
  valorFaturadoModal: any;

  lucModalEdicao: any;
  rubricaModalEdicao: any;
  TituloModalEdicao: string;
  competenciaModalEdicao: string;
  vencimentoModalEdicao: Date;
  valorFaturadoModalEdicao: any;

  constructor(private primeNGConfig: PrimeNGConfig, private fb: FormBuilder,
    private valoresFaturadosService: ValoresFaturadosService,
    private lucService: LucService,
    private marcaService: MarcaService,
    private tipoInstrumentoService: TipoInstrumentoService,
    private rubricaService: RubricaService,
    private contratoLucsService: ContratoLucsService,
    private messageService: MessageService,
    private localStorageService: LocalStorageService,
    private contratoLocacaoService: ContratoLocacaoService,
    private confirmationService: ConfirmationService,
    private _route: ActivatedRoute) {
    this.tipoLocacaoSelecionada = 1;
    this.CarregarTipoInstrumento();
    this.CarregarMarcas();
    this.CarregarUnidades();
    this.CarregarRubricas();
  }

  ngOnInit(): void {
    this.MesAnoProcessamento = this.localStorageService.get("MesAnoProcessamento");
    this.statusCobranca = "AMBOS";
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
  CarregarRubricas() {
    this.rubricaService.getAll().subscribe(
      (rubrica: Rubrica[]) => {
        this.rubricas = rubrica;
      },
      (erro: any) => {
        console.log("Erro ao carregar os tipos de instrumento. Erro: " + erro);
      }
    );
  }

  PesquisarValoresFaturados() {
    this.valoresFaturadosSelecionados = [];

    this.valorFaturadoFiltro.tipoLocacaoFiltro = this.tipoLocacaoSelecionada;
    this.valorFaturadoFiltro.anoMesProcessamentoFiltroDe = !!this.valmesAnoProcDe ? Number(this.valmesAnoProcDe.substring(3, 7)) * 100 + Number(this.valmesAnoProcDe.substring(0, 2)) : 0;
    this.valorFaturadoFiltro.anoMesProcessamentoFiltroAte = !!this.valmesAnoProcAte ? Number(this.valmesAnoProcAte.substring(3, 7)) * 100 + Number(this.valmesAnoProcAte.substring(0, 2)) : 0;
    this.valorFaturadoFiltro.lucsFiltro = !!this.lucSelecionada ? this.lucSelecionada : [];
    this.valorFaturadoFiltro.marcasFiltro = !!this.marcaSelecionada ? this.marcaSelecionada : [];
    this.valorFaturadoFiltro.vencimentoNDFiltroDe = !!this.vencimentoDe ? new Date(this.vencimentoDe) : new Date(1901, 1, 1);
    this.valorFaturadoFiltro.vencimentoNDFiltroAte = !!this.vencimentoAte ? new Date(this.vencimentoAte) : new Date(1901, 1, 1);
    this.valorFaturadoFiltro.enviados = this.statusCobranca == "AMBOS" ? null : this.statusCobranca == "ENVIADO" ? true : false;

    this.valoresFaturadosService.filter(this.valorFaturadoFiltro).toPromise().then(dados => {
      let retorno: ValoresFaturados[];

      retorno = dados;

      retorno.forEach((ret, index) => {
        ret.rubrica = new Rubrica();
        ret.luc = new Luc();
        let dataBanco: any;
        dataBanco = ret.vencimentoNd;
        ret.idShopping = Number(this.localStorageService.GetShoppingAtivo());
        ret.vencimentoNd = new Date(dataBanco);
        Object.assign(ret.rubrica, this.rubricas.filter(r => r.id == ret.idRubrica)[0]);
        ret.nomeSerie = this.series[ret.rubrica.idSerie];
        ret.idSerie = ret.rubrica.idSerie;
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
      this.valoresFaturados = retorno;
    });
  }

  AbrirModalValoresFaturados() {
    this.submitted = false;
    this.lucSelecionadaModal = undefined;
    this.rubricaSelecionadaModal = undefined;
    this.competenciaModal = "";
    this.vencimentoModal = new Date();
    this.valorFaturadoModal = undefined;
    this.ModalValoresFaturados = true;
    this.TituloModal = "Adicionar novo Valor";
  }

  Aprovar() {
    let index: number;

    index = this.valoresFaturados.indexOf(this.valorFaturadoEdicao);

    if (this.valoresFaturadosSelecionados.length == 0 || !this.valoresFaturadosSelecionados)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Selecione ao menos um valor para aprovar/desaprovar.' });
    else if (this.valoresFaturadosSelecionados.filter(val => val.idNd > 0).length > 0)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Existem itens selecionados que já foram enviados para cobrança. Impossível continuar com a operação.' });
    else {
      this.confirmationService.confirm({
        message: 'Tem certeza que deseja aprovar/desaprovar os valores selecionados?',
        header: 'Confirmar',
        acceptLabel: "Sim",
        rejectLabel: "Não",
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.valoresFaturadosService.aprovarValores(this.valoresFaturadosSelecionados).toPromise().then(dados => {
            this.valoresFaturadosSelecionados.forEach(v => {
              index = this.valoresFaturados.indexOf(v);
              this.valoresFaturados[index].eAprovado = this.valoresFaturados[index].eAprovado ? false : true;
              this.valoresFaturadosSelecionados = [];
            })
            this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: 'Valor(es) aprovado(s)/desaprovado(s).', life: 3000 });
          }).catch(err => {
            this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Ocorreu um erro ao aprovar/desaprovar.' });
          });
        }
      });
    }
  }

  EnviarCobranca() {
    if (this.valoresFaturadosSelecionados.length == 0 || !this.valoresFaturadosSelecionados)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Selecione ao menos um valor para enviar.' });
    else if (this.statusCobranca != "NAOENVIADO")
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Utilize a opção "Não enviados para cobrança."' });
    else if (this.valoresFaturadosSelecionados.filter(v => !(v.eAprovado)).length > 0)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Existem itens não aprovados na seleção.' });
    else {
      this.confirmationService.confirm({
        message: 'Tem certeza que deseja enviar os valores selecionados?',
        header: 'Confirmar',
        acceptLabel: "Sim",
        rejectLabel: "Não",
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.valoresFaturadosService.enviarValores(this.valoresFaturadosSelecionados).toPromise().then(dados => {
            this.valoresFaturados = this.valoresFaturados.filter(val => !this.valoresFaturadosSelecionados.includes(val));
            this.valoresFaturadosSelecionados = [];
            this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: 'Item(ns) enviado(s) com sucesso.', life: 3000 });
          }).catch(err => {
            this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Ocorreu um erro ao enviar para cobranca.' });
          });
        }
      });
    }
  }

  RetornarCobranca() {
    if (this.valoresFaturadosSelecionados.length == 0 || !this.valoresFaturadosSelecionados)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Selecione ao menos um valor para retornar.' });
    else if (this.statusCobranca != "ENVIADO")
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Utilize a opção "Enviados para cobrança."' });
    else if (this.valoresFaturadosSelecionados.filter(v => !(v.eAprovado)).length > 0)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Existem itens não aprovados na seleção.' });
    else {
      this.confirmationService.confirm({
        message: 'Tem certeza que deseja retornar os valores selecionados? Todos os valores que compõem as NDs selecionadas serão devolvidos ao faturamento, mesmo que um dos itens não tenha sido selecionado.',
        header: 'Confirmar',
        acceptLabel: "Sim",
        rejectLabel: "Não",
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.valoresFaturadosService.retornarValores(this.valoresFaturadosSelecionados).toPromise().then(dados => {
            this.valoresFaturados = this.valoresFaturados.filter(val => !this.valoresFaturadosSelecionados.includes(val));
            this.valoresFaturadosSelecionados = [];
            this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: 'Item(ns) retornado(s) com sucesso.', life: 3000 });
          }).catch(err => {
            this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Ocorreu um erro ao retornar da cobranca. ' + err.error.text });
          });
        }
      });
    }
  }

  checkSameItemND(event: any, valorFaturado: any) {
    if (!!valorFaturado.idNd) {
      if (event.target.ariaChecked == "true") {
        this.valoresFaturadosSelecionados = this.valoresFaturadosSelecionados.filter(val => val != valorFaturado);
        this.valoresFaturadosSelecionados = this.valoresFaturadosSelecionados.concat(this.valoresFaturados.filter(v => v.idNd == valorFaturado.idNd));
      }
      else {
        this.valoresFaturadosSelecionados = this.valoresFaturadosSelecionados.filter(val => val.idNd != valorFaturado.idNd);
      }
    }
  }

  EsconderModal() {
    this.submitted = false;
    this.ModalValoresFaturados = false;
    this.TituloModal = "";
  }

  SalvarValorFaturado(valorFaturado: ValoresFaturados) {

    if (!this.valoresFaturados) this.valoresFaturados = [];

    this.submitted = true;

    if (this.TituloModal === "Adicionar novo Valor") {

      if (!!this.lucSelecionadaModal &&
        !!this.competenciaModal &&
        !!this.vencimentoModal &&
        !!this.rubricaSelecionadaModal &&
        !!this.valorFaturadoModal
      ) {

        for (var i = 0; i < this.lucSelecionadaModal.length; i++) {
          for (var j = 0; j < this.rubricaSelecionadaModal.length; j++) {
            this.AdicionaValorFaturado(i, j);
          }
        }
      }
    }
    else {

      let index: number;

      index = this.valoresFaturados.indexOf(this.valorFaturadoEdicao);

      this.valorFaturadoEdicao.anoCompetencia = parseInt(this.competenciaModalEdicao.substring(3, 7));
      this.valorFaturadoEdicao.mesCompetencia = parseInt(this.competenciaModalEdicao.substring(0, 2));
      this.valorFaturadoEdicao.vencimentoNd = new Date(this.vencimentoModalEdicao.toDateString());
      this.valorFaturadoEdicao.valorFaturado = Number(this.valorFaturadoModalEdicao);

      this.valoresFaturadosService.put(this.valorFaturadoEdicao).toPromise().then(dados => {
        this.valoresFaturados[index] = this.valorFaturadoEdicao;
        this.ModalValoresFaturadosEdicao = false;
        this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: 'Luc: ' + this.lucs.filter(r => r.id == this.valorFaturadoEdicao.luc.id)[0].nomeLuc + '. Valor incluído com sucesso.(' + this.rubricas.filter(r => r.id == this.valorFaturadoEdicao.rubrica.id)[0].nomeRubrica + ')' });
      });
    }
  }

  EditarValorFaturado(valorFaturado: ValoresFaturados) {
    this.submitted = false;
    this.ModalValoresFaturadosEdicao = true;
    this.TituloModal = "Editar Valor.";

    this.lucModalEdicao = valorFaturado.luc.nomeLuc;
    this.rubricaModalEdicao = valorFaturado.rubrica.nomeRubrica;
    this.competenciaModalEdicao = valorFaturado.mesCompetencia < 10 ? "0" + valorFaturado.mesCompetencia + "/" + valorFaturado.anoCompetencia : valorFaturado.mesCompetencia + "/" + valorFaturado.anoCompetencia;
    this.valorFaturadoModalEdicao = valorFaturado.valorFaturado;
    this.vencimentoModalEdicao = valorFaturado.vencimentoNd;

    this.valorFaturadoEdicao = valorFaturado;
  }

  limparGrid() {
    this.valoresFaturados = [];
  }

  DeletarValorFaturado(valorFaturado: any) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja excluir o item?',
      header: 'Confirmar',
      acceptLabel: "Sim",
      rejectLabel: "Não",
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.valoresFaturadosService.delete(valorFaturado.id).toPromise().then(dados => {
          this.valoresFaturados = this.valoresFaturados.filter(vr => vr.id != valorFaturado.id);
          this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: 'Item excluído com sucesso.' });
        }).catch(err => {
          this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Ocorreu um erro ao exclur.' });
        })
      }
    });
  }

  deleteSelectedValues() {
    if (!this.valoresFaturadosSelecionados || this.valoresFaturadosSelecionados.length == 0 || !this.valoresFaturadosSelecionados)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Selecione ao menos um valor para excluir.' });
    else if (this.valoresFaturadosSelecionados.filter(val => val.idNd > 0).length > 0)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Existem itens selecionados que já foram enviados para cobrança. Impossível seguir com a exclusão.' });
    else {
      this.confirmationService.confirm({
        message: 'Tem certeza que deseja excluir os valores selecionados?',
        header: 'Confirmar',
        acceptLabel: "Sim",
        rejectLabel: "Não",
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
            this.valoresFaturadosService.deletarValores(this.valoresFaturadosSelecionados).toPromise().then(dados => {
              this.valoresFaturados = this.valoresFaturados.filter(val => !this.valoresFaturadosSelecionados.includes(val));
              this.valoresFaturadosSelecionados = null;
              this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: 'Valores Enviados com sucesse..', life: 3000 });
            }).catch(err => {
              this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Ocorreu um erro ao enviar para cobrança.' });
            });
        }
      });
    }
  }

  AdicionaValorFaturado(i: number, j: number) {
    let vrf: ValoresFaturados = new ValoresFaturados();

    this.contratoLucsService.getInstrumentoIdByLucId(this.lucSelecionadaModal[i]).toPromise().then(
      (contratoLucs: ContratoLucs) => {
        this.contratoLucs = contratoLucs;
        vrf.idShopping = Number(this.localStorageService.GetShoppingAtivo());
        vrf.idInstrumento = this.contratoLucs.idInstrumento;
        vrf.idRubrica = this.rubricaSelecionadaModal[j];
        vrf.anoCompetencia = parseInt(this.competenciaModal.substring(3, 7));
        vrf.mesCompetencia = parseInt(this.competenciaModal.substring(0, 2));
        vrf.anoProcessamento = parseInt(this.MesAnoProcessamento.substring(3, 7));
        vrf.mesProcessamento = parseInt(this.MesAnoProcessamento.substring(0, 2));
        vrf.vencimentoNd = new Date(this.vencimentoModal.toDateString());
        vrf.valorFaturado = Number(this.valorFaturadoModal);
        vrf.valorCalculado = 0.00;
        vrf.rubrica = new Rubrica();
        vrf.luc = new Luc();
        Object.assign(vrf.rubrica, this.rubricas.filter(r => r.id == this.rubricaSelecionadaModal[j])[0]);
        vrf.idSerie = vrf.rubrica.idSerie;
        vrf.nomeSerie = this.series[vrf.rubrica.idSerie];
        Object.assign(vrf.luc, this.lucs.filter(r => r.id == this.lucSelecionadaModal[i])[0]);
      }).then(dados => {
        this.contratoLocacaoService.getIdInstrumento(vrf.idInstrumento).toPromise().then(dados => {
          vrf.marca = new Marca();
          Object.assign(vrf.marca, this.marcas.filter(r => r.id == dados.idMarca)[0]);
          vrf.idSeqAltContratoLocacao = dados.id;
          vrf.idDescricaoAlternativa = 0;
        });
      }).then(dados => {
        this.valoresFaturadosService.post(vrf).toPromise().then(dados => {
          let vrfIncluidi: any;
          vrfIncluidi = dados;
          vrf.id = vrfIncluidi.id;
          this.valoresFaturados.push(vrf);
          this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: 'Luc: ' + this.lucs.filter(r => r.id == this.lucSelecionadaModal[i])[0].nomeLuc + '. Valor incluído com sucesso.(' + this.rubricas.filter(r => r.id == this.rubricaSelecionadaModal[j])[0].nomeRubrica + ')' });
          this.EsconderModal();
        });
      }).catch((err) => {
        this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Luc: ' + this.lucs.filter(r => r.id == this.lucSelecionadaModal[i])[0].nomeLuc + '.Ocorreu um erro ao salvar.' });
      });
  }

  exportarParaExcel() {
    if (!this.valoresFaturadosSelecionados || this.valoresFaturadosSelecionados.length == 0 || !this.valoresFaturadosSelecionados)
      this.messageService.add({ severity: 'error', summary: 'Erro', detail: 'Selecione ao menos um valor para exportar.' });
    else {
      let _itens: any[] = []

      this.valoresFaturadosSelecionados.forEach(v => {
        _itens.push({
          Instrumento: v.idInstrumento,
          Unidade: v.luc.nomeLuc,
          Marca: v.marca.nomeMarca,
          Processamento: v.mesProcessamento + '/' + v.anoProcessamento,
          Competencia: v.mesCompetencia + '/' + v.anoCompetencia,
          Rubrica: v.rubrica.nomeRubrica,
          ValorCalculado: v.valorCalculado,
          ValorFaturado: v.valorFaturado,
          Vencimento: v.vencimentoNd,
          Nd: v.idNd
        })
      });

      import("xlsx").then(xlsx => {
        var wb = xlsx.utils.book_new();
        const worksheet = xlsx.utils.json_to_sheet(_itens);
        xlsx.utils.book_append_sheet(wb, worksheet, "Valor Faturado");
        xlsx.writeFile(wb, `${'faturamento_export_' + new Date().getTime()}.xlsx`);
      });
    }
  }
}

