import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { ItensNDService } from '../Servicos/ItensNd/itens-nd.service';
import { RubricaService } from '../Servicos/Rubrica/rubrica.service';
import { HttpHeaders } from '@angular/common/http';
import * as XLSX from 'xlsx';
import { ListaExcel } from '../Models/Excel';
import { Rubrica } from '../Models/rubrica';
import { ItensND } from '../Models/ItensND';
import { NotificacaoPost } from '../Models/notificacao-post';

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
  arraylist: ListaExcel[];

  //url para importar
  //urlBase = `${environment.urlBase}/api/ItensNd/Upload`;
  arquivosParaEnviar: any[] = [];

  rubrica: Rubrica = new Rubrica();
  rubricaImportar: Rubrica = new Rubrica();
  unidade: ItensND = new ItensND();

  //selected unidade
  unidadesSelecionadas: string[];
  unidades: any[];
  valoresDeConsumos: any[];
  valorDeConsumoSelecionado: any[];
  tiposDeConsumos: any[];

  submitted: boolean;
  ModalUnidade: boolean;
  TituloModal: string;
  tipoDeConsumoSelecionado: any;
  
  constructor(private fb: FormBuilder,
    private itensNDService: ItensNDService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private rubricaService: RubricaService) {
    this.CarregarRubricas();
  }

  ngOnInit(): void {

  }

  CarregarRubricas() {
    this.rubricaService.getAll().subscribe(
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
      debugger
      for (let j = 0; j < this.arraylist.length; j++) {
        console.log("unidade:" + this.arraylist[j].Unidade);
        console.log("valor:" + this.arraylist[j].Valor);

        let unidade = new ItensND();
        let rubrica = new Rubrica();

        unidade.nome = this.arraylist[j].Unidade;
        unidade.valorPrincipalRubrica = this.arraylist[j].Valor;

        rubrica = this.tiposDeConsumos.find(i=>i.id == this.unidade.rubrica);
        unidade.rubrica = rubrica;
        this.unidades.push(unidade);
      }

      //console.log(XLSX.utils.sheet_to_json(worksheet, { raw: true }));
      //var arraylist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      //this.filelist = [];
      //console.log(this.filelist)
    }
  }

  AbrirModalNovaUnidade() {
    this.unidade = new ItensND();
    this.submitted = false;
    this.ModalUnidade = true;
    this.TituloModal = "Adicionar nova Unidade";
  }

  EsconderModal() {
    this.ModalUnidade = false;
    this.submitted = false;
  }

  EncontrarIdDaUnidadeNoCrud(id: string): number {
    let index = -1;
    for (let i = 0; i < this.unidades.length; i++) {
      if (this.unidades[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }

  SalvarUnidade() {
    
    this.submitted = true;

    if (!this.unidades) this.unidades = [];

    if (!this.unidade.rubrica)
      this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Tipo Consumo não encontrado.', life: 3000 });

    if (this.unidade.nome.trim()) {
      if (this.unidade.id) {
        this.unidades[this.EncontrarIdDaUnidadeNoCrud(this.unidade.id.toString())] = this.unidade;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade Atualizada', life: 3000 });
      }
      else {
        let nmTipoCosumo = this.tiposDeConsumos.find(i => i.id == this.unidade.rubrica).nomeRubrica;
        this.unidade.rubrica.nomeRubrica = nmTipoCosumo;
        this.unidades.push(this.unidade);
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade Adicionada', life: 3000 });
      }

      this.unidades = [...this.unidades];
      this.ModalUnidade = false;
      this.unidade = new ItensND();
    }
  }

  EditarUnidade(unidade: any) {
    this.unidade = { ...unidade };
    this.ModalUnidade = true;
    this.TituloModal = "Editar a unidade " + unidade.nome;
  }

  DeletarUnidade(unidade: any) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + unidade.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.unidades = this.unidades.filter(val => val.id !== unidade.id);
        this.unidade = new ItensND();
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade deletada', life: 3000 });
      }
    });
  }

  DeletarUnidadesSelecionadas() {
    this.confirmationService.confirm({
      message: 'Deseja deletar todos?',
      header: 'Confirm',
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

    debugger

    //unidades
    this.itensNDService.post(this.unidades).subscribe(
      (notificacaoPost: NotificacaoPost) => {
        this.messageService.add({ severity: 'success', summary: 'Unidades cadastrada com sucesso.', detail: 'Via MessageService' });
      },
      (error: any) => {
        console.log('Erro: ' + error);
      }
    );
  }
}
