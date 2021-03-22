import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { ItensNDService } from '../Servicos/itens-nd.service';
import { HttpHeaders } from '@angular/common/http';
import * as XLSX from 'xlsx';

class TipoConsumo {
  id: number;
  nomeDescricaAlternativa: string
}

class Unidade {
  id: number;
  nome: string;
  valor: number;
  tipoDeConsumoSelecionado: TipoConsumo;
}

class ListaExcel {
  Unidade: string;
  Valor: number;
}

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
  urlBase = `${environment.urlBase}/api/ItensNd/Upload`;
  arquivosParaEnviar: any[] = [];

  tipoConsumo: TipoConsumo;

  //selected unidade
  unidadesSelecionadas: string[];
  unidades: any[];
  unidade: Unidade;
  valoresDeConsumos: any[];
  valorDeConsumoSelecionado: any[];
  submitted: boolean;
  ModalUnidade: boolean;
  TituloModal: string;
  tipoDeConsumoSelecionado: any;
  tiposDeConsumos: any[];

  constructor(private fb: FormBuilder, private itensNDService: ItensNDService, private messageService: MessageService, private confirmationService: ConfirmationService) {
    this.CarregarUnidades();
  }

  ngOnInit(): void {

  }

  CarregarUnidades() {
    this.itensNDService.GetIdItensNdEDescricaoAlternativa().subscribe(
      (itensND: any[]) => {
        this.tiposDeConsumos = itensND;
      },
      (erro: any) => {
        console.log("Erro ao carregar os usuarios. Erro: " + erro);
      }
    );
  }

  Upload(event) {
    debugger
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

        this.unidade = new Unidade();
        this.tipoConsumo = new TipoConsumo();

        this.unidade.nome = this.arraylist[j].Unidade;
        this.unidade.valor = this.arraylist[j].Valor;

        this.tipoConsumo.nomeDescricaAlternativa = "n/a";
        this.unidade.tipoDeConsumoSelecionado = this.tipoConsumo;
        this.unidades.push(this.unidade);
      }

      //console.log(XLSX.utils.sheet_to_json(worksheet, { raw: true }));
      //var arraylist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      //this.filelist = [];
      //console.log(this.filelist)
    }
  }

  AbrirModalNovaUnidade() {
    this.unidade = new Unidade();
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

    if (!this.unidade.tipoDeConsumoSelecionado)
      this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Tipo Consumo não encontrado.', life: 3000 });

    if (this.unidade.nome.trim()) {
      if (this.unidade.id) {
        this.unidades[this.EncontrarIdDaUnidadeNoCrud(this.unidade.id.toString())] = this.unidade;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade Updated', life: 3000 });
      }
      else {
        let nmTipoCosumo = this.tiposDeConsumos.find(i => i.id == this.unidade.tipoDeConsumoSelecionado).nomeDescricaAlternativa;
        this.unidade.tipoDeConsumoSelecionado.nomeDescricaAlternativa = nmTipoCosumo;
        this.unidades.push(this.unidade);
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Unidade Adicionada', life: 3000 });
      }

      this.unidades = [...this.unidades];
      this.ModalUnidade = false;
      this.unidade = new Unidade();
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
        this.unidade = new Unidade();
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
}
