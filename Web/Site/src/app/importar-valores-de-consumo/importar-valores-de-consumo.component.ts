import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
//import { ItensNDService } from '../Servicos/ItensNd/itens-nd.service';
import { ImportarValoresDeConsumoService } from '../Servicos/ImportarValoresDeConsumo/importar-valores-de-consumo.service';
import { RubricaService } from '../Servicos/Rubrica/rubrica.service';
import { HttpHeaders } from '@angular/common/http';
import * as XLSX from 'xlsx';
import { ListaExcelImportarValoresDeConsumo } from '../Models/Excel';
import { Rubrica } from '../Models/rubrica';
import { ItensND } from '../Models/ItensND';
import { NotificacaoPost } from '../Models/notificacao-post';
import { Luc } from '../Models/luc';
import { ValoresFaturado } from '../Models/valores-faturado';
import { ImportarValoresDeConsumoModel } from '../Models/importar-valores-de-consumo-model';

@Component({
  selector: 'app-importar-valores-de-consumo',
  templateUrl: './importar-valores-de-consumo.component.html',
  styleUrls: ['./importar-valores-de-consumo.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ImportarValoresDeConsumoComponent implements OnInit {

  file: File;
  arrayBuffer: any;
  filelist: any;
  arraylist: ListaExcelImportarValoresDeConsumo[];

  //url para importar
  //urlBase = `${environment.urlBase}/api/ItensNd/Upload`;
  arquivosParaEnviar: any[] = [];

  rubrica: Rubrica = new Rubrica();
  rubricaImportar: Rubrica = new Rubrica();
  unidade: ImportarValoresDeConsumoModel;

  //selected unidade
  unidadesSelecionadas: ImportarValoresDeConsumoModel[];
  unidades: ImportarValoresDeConsumoModel[];
  valoresDeConsumos: any[];
  valorDeConsumoSelecionado: any[];
  tiposDeConsumos: Rubrica[];
  idTipoDeConsumoSelecionadoNaImportacao: number;
  adicionarValorFaturado: boolean;
  submitted: boolean;
  ModalUnidade: boolean;
  TituloModal: string;
  tipoDeConsumoSelecionado: any;

  //variaveis da modal
  unidadeModalNomeLuc: string;
  unidadeModalValorFaturado: number;
  //unidadeModalTipoDeConsumo: number;
  unidadeModalTipoDeConsumo: number[] = [];

  constructor(private fb: FormBuilder,
    private itensNDService: ImportarValoresDeConsumoService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private rubricaService: RubricaService) {
    this.CarregarRubricas();
  }

  ngOnInit(): void {

  }

  CarregarRubricas() {
    this.rubricaService.Get().subscribe(
      (rubrica: Rubrica[]) => {
        this.tiposDeConsumos = rubrica;
      },
      (erro: any) => {
        console.log("Erro ao carregar os usuarios. Erro: " + erro);
      }
    );
  }

  Upload(event) {

    if (!this.unidades) this.unidades = [];

    this.file = event.files[0];

    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(this.file);
    fileReader.onload = (e) => {
      this.arrayBuffer = fileReader.result;
      var data = new Uint8Array(this.arrayBuffer);
      var arr = new Array();
      for (var i = 0; i != data.length; ++i) arr[i] = String.fromCharCode(data[i]);
      var bstr = arr.join("");
      var workbook = XLSX.read(bstr, { type: "binary" });
      var first_sheet_name = workbook.SheetNames[0];
      var worksheet = workbook.Sheets[first_sheet_name];
      //console.log(XLSX.utils.sheet_to_json(worksheet, { raw: true }));
      this.arraylist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      
      for (let j = 0; j < this.arraylist.length; j++) {
        console.log("unidade:" + this.arraylist[j].Unidade);
        console.log("valor:" + this.arraylist[j].Valor);

        let unidade = new Luc();
        let rubrica = new Rubrica();
        let valoresFaturado = new ValoresFaturado();
        let importarValoresDeConsumoModel = new ImportarValoresDeConsumoModel();

        unidade.nomeLuc = this.arraylist[j].Unidade;
        valoresFaturado.valorFaturado = this.arraylist[j].Valor;

        if (this.idTipoDeConsumoSelecionadoNaImportacao)
          rubrica = this.tiposDeConsumos.find(i => i.id == this.idTipoDeConsumoSelecionadoNaImportacao);
        else
          rubrica.nomeRubrica = "";

        importarValoresDeConsumoModel.luc = unidade;
        importarValoresDeConsumoModel.valoresFaturado = valoresFaturado;
        importarValoresDeConsumoModel.rubrica = rubrica;

        this.unidades.push(importarValoresDeConsumoModel);
      }

      //console.log(XLSX.utils.sheet_to_json(worksheet, { raw: true }));
      //var arraylist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      //this.filelist = [];
      //console.log(this.filelist)
    }
  }

  AbrirModalNovaUnidade() {
    this.unidade = new ImportarValoresDeConsumoModel();
    this.submitted = false;
    this.ModalUnidade = true;
    this.TituloModal = "Adicionar novo valor Faturado";
    this.ResetarDadosDaModal();
  }

  EsconderModal() {
    this.ModalUnidade = false;
    this.submitted = false;
    this.ResetarDadosDaModal();
  }

  ResetarDadosDaModal() {
    this.unidadeModalNomeLuc = '';
    this.unidadeModalValorFaturado = null;
    this.unidadeModalTipoDeConsumo = [];
  }

  EncontrarIdDaUnidadeNoCrud(nomeLuc: string): number {
    let index = -1;
    for (let i = 0; i < this.unidades.length; i++) {
      if (this.unidades[i].luc.nomeLuc === nomeLuc) {
        index = i;
        break;
      }
    }
    return index;
  }

  SalvarUnidade() {
    this.submitted = true;
    if (!this.unidades) this.unidades = [];

    //if (!this.unidadeModal.idTipoDeConsumoModal)
    //  this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Tipo Consumo não encontrado.', life: 3000 });
    
    //if (this.adicionarValorFaturado) {
    //  this.unidades[this.EncontrarIdDaUnidadeNoCrud(this.unidade.luc.id)] = this.unidade;
    //  this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade Atualizada', life: 3000 });
    //}
    //else {
    //  let nmTipoCosumo = this.tiposDeConsumos.find(i => i.id == this.unidadeModal.idTipoDeConsumoModal).nomeRubrica;
    //  this.unidade.rubrica.nomeRubrica = nmTipoCosumo;
    //  this.unidades.push(this.unidadeModal);
    //  this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade Adicionada', life: 3000 });
    //}

    let unidade = new Luc();
    let rubrica = new Rubrica();
    let valoresFaturado = new ValoresFaturado();
    let importarValoresDeConsumoModel = new ImportarValoresDeConsumoModel();

    if (this.adicionarValorFaturado) {

      unidade.nomeLuc = this.unidadeModalNomeLuc;
      valoresFaturado.valorFaturado = this.unidadeModalValorFaturado;
      rubrica = this.tiposDeConsumos.find(i => i.id == this.unidadeModalTipoDeConsumo[0]);
      importarValoresDeConsumoModel.luc = unidade;
      importarValoresDeConsumoModel.valoresFaturado = valoresFaturado;
      importarValoresDeConsumoModel.rubrica = rubrica;
      this.unidades.push(importarValoresDeConsumoModel);

    } else {

      unidade.nomeLuc = this.unidadeModalNomeLuc;
      valoresFaturado.valorFaturado = this.unidadeModalValorFaturado;
      rubrica = this.tiposDeConsumos.find(i => i.id == this.unidadeModalTipoDeConsumo[0]);
      importarValoresDeConsumoModel.luc = unidade;
      importarValoresDeConsumoModel.valoresFaturado = valoresFaturado;
      importarValoresDeConsumoModel.rubrica = rubrica;
      this.unidades[this.EncontrarIdDaUnidadeNoCrud(this.unidade.luc.nomeLuc)] = importarValoresDeConsumoModel;
      this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade Atualizada', life: 3000 });    
    }
    this.ModalUnidade = false;
  }

  EditarUnidade(unidade: ImportarValoresDeConsumoModel) {

    debugger

    this.unidade = { ...unidade };
    this.TituloModal = "Editar a unidade " + unidade.luc.nomeLuc;
    this.ModalUnidade = true;
    this.adicionarValorFaturado = false;    
    this.unidadeModalNomeLuc = this.unidade.luc.nomeLuc;
    this.unidadeModalValorFaturado = unidade.valoresFaturado.valorFaturado;
    this.unidadeModalTipoDeConsumo = [];
    if (this.unidade.rubrica.id) {
      let rubricaId = this.tiposDeConsumos.find(i => i.id == this.unidade.rubrica.id).id;
      this.unidadeModalTipoDeConsumo[0] = rubricaId;
    }
  }

  DeletarUnidade(unidade: ImportarValoresDeConsumoModel) {
    this.confirmationService.confirm({
      message: 'Deseja excluir o valor de importação para a unidade <label style="color:red;"><b>' + unidade.luc.nomeLuc + '</b></labe>?',
      //header: 'Confirma',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.unidades = this.unidades.filter(val => val.luc.nomeLuc !== unidade.luc.nomeLuc);
        this.unidade = new ImportarValoresDeConsumoModel();
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade deletada', life: 3000 });
      }
    });
  }

  DeletarUnidadesSelecionadas() {
    this.confirmationService.confirm({
      message: 'Deseja deletar todos?',
      //header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.unidades = this.unidades.filter(val => !this.unidadesSelecionadas.includes(val));
        this.unidadesSelecionadas = null;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidades deletadas', life: 3000 });
      }
    });
  }

  onUpload(event) {
    for (let file of event.files) {
      this.arquivosParaEnviar.push(file);
    }

    this.messageService.add({ severity: 'info', summary: 'File Uploaded', detail: '' });
  }

  SalvarValoresImportados() {

    

    //unidades
    this.itensNDService.post(this.unidades).subscribe(
      (notificacaoPost: NotificacaoPost) => {
        this.messageService.add({ severity: 'success', summary: 'Valores de unidade cadastrado com sucesso.', detail: 'Via MessageService' });
      },
      (error: any) => {
        debugger
        console.log('Erro: ' + error);
      }
    );
  }
}
