import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

//primeng
import { ConfirmationService, MessageService } from 'primeng/api';

import { ItensNDService, ItensNDServiceModel } from '../Servicos/itens-nd.service';

@Component({
  selector: 'app-importar-valores-de-consumo',
  templateUrl: './importar-valores-de-consumo.component.html',
  styleUrls: ['./importar-valores-de-consumo.component.css'],
  providers: [MessageService]
})
export class ImportarValoresDeConsumoComponent implements OnInit {

  //selected unidade
  unidadesSelecionadas: string[];
  unidades: ItensNDServiceModel[];

  //importarValorDeConsumoDialog: boolean;
  //importarValorDeConsumos: any[];
  //importarValorDeConsumo: any;
  
  //submitted: boolean;
  //statuses: any[];
  valoresDeConsumos: any[];
  valorDeConsumoSelecionado: any[];

  constructor(private fb: FormBuilder, private messageService: MessageService, private itensNDService: ItensNDService) {
    //this.Formulario();
    this.CarregarUnidades();
  }

  ngOnInit(): void {
    //this.importarValorDeConsumoService.getImportarValorDeConsumos().then(data => this.importarValorDeConsumos = data);

    //this.statuses = [
    //  { label: 'INSTOCK', value: 'instock' },
    //  { label: 'LOWSTOCK', value: 'lowstock' },
    //  { label: 'OUTOFSTOCK', value: 'outofstock' }
    //];
  }

  CarregarUnidades() {
    this.itensNDService.GetIdItensNdEDescricaoAlternativa().subscribe(
      (itensNDServiceModel: ItensNDServiceModel[]) => {
        this.unidades = itensNDServiceModel;
      },
      (erro: any) => {
        console.log("Erro ao carregar os usuarios. Erro: " + erro);
      }
    );
  }

  //AbrirModalCriarNovo() {
  //  this.importarValorDeConsumo = {};
  //  this.submitted = false;
  //  this.importarValorDeConsumoDialog = true;
  //}

  //DeletarValoresDeConsumoSelecionados() {
  //  this.confirmationService.confirm({
  //    message: 'Deseja apagar o valor de consumo selecionado?',
  //    header: 'Confirm',
  //    icon: 'pi pi-exclamation-triangle',
  //    accept: () => {
  //      this.importarValorDeConsumos = this.importarValorDeConsumos.filter(val => !this.valorDeConsumoSelecionado.includes(val));
  //      this.valorDeConsumoSelecionado = null;
  //      this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Valor de consumo deletado.', life: 3000 });
  //    }
  //  });
  //}

  //EditarValorDeConsumo(importarValorDeConsumo: any) {
  //  this.importarValorDeConsumo = { ...importarValorDeConsumo };
  //  this.importarValorDeConsumoDialog = true;
  //}

  //DeletarValorDeConsumoSelecionado(importarValorDeConsumo: any) {
  //  this.confirmationService.confirm({
  //    message: 'Deseja deletar o valor de consumo ' + importarValorDeConsumo.name + '?',
  //    header: 'Confirm',
  //    icon: 'pi pi-exclamation-triangle',
  //    accept: () => {
  //      this.importarValorDeConsumos = this.importarValorDeConsumos.filter(val => val.id !== importarValorDeConsumo.id);
  //      this.importarValorDeConsumo = {};
  //      this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Valor de consumo deletado', life: 3000 });
  //    }
  //  });
  //}

  //EscondeModal() {
  //  this.importarValorDeConsumoDialog = false;
  //  this.submitted = false;
  //}

  //SalvarValores() {
  //  this.submitted = true;

  //  if (this.importarValorDeConsumo.name.trim()) {
  //    if (this.importarValorDeConsumo.id) {
  //      this.importarValorDeConsumos[this.findIndexById(this.importarValorDeConsumo.id)] = this.importarValorDeConsumo;
  //      this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'ImportarValorDeConsumo Updated', life: 3000 });
  //    }
  //    else {
  //      this.importarValorDeConsumo.id = this.createId();
  //      this.importarValorDeConsumo.image = 'importarValorDeConsumo-placeholder.svg';
  //      this.importarValorDeConsumos.push(this.importarValorDeConsumo);
  //      this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'ImportarValorDeConsumo Created', life: 3000 });
  //    }

  //    this.importarValorDeConsumos = [...this.importarValorDeConsumos];
  //    this.importarValorDeConsumoDialog = false;
  //    this.importarValorDeConsumo = {};
  //  }
  //}

  //findIndexById(id: string): number {
  //  let index = -1;
  //  for (let i = 0; i < this.importarValorDeConsumos.length; i++) {
  //    if (this.importarValorDeConsumos[i].id === id) {
  //      index = i;
  //      break;
  //    }
  //  }

  //  return index;
  //}

  //createId(): string {
  //  let id = '';
  //  var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  //  for (var i = 0; i < 5; i++) {
  //    id += chars.charAt(Math.floor(Math.random() * chars.length));
  //  }
  //  return id;
  //}

}
