import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router'

//primeng
import { Table } from 'primeng/table';
import { MessageService } from 'primeng/api';

import jsPDF from 'jspdf';
import "jspdf-autotable";

//models
import { Usuario } from '../Models/Usuario';
import { Estado } from '../Models/Estado';
import { Cidade } from '../Models/Cidade';
import { Sexo } from '../Models/Sexo';

//serviços
import { EstadoService } from '../Servicos/Util/Estado.service';
import { CidadeService } from '../Servicos/Cidade/cidade.service';
import { UsuarioService } from '../Servicos/Usuario/usuario.service';
import { SexoService } from '../Servicos/Sexo/sexo.service';
import autoTable from 'jspdf-autotable';



@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css'],
  providers: [MessageService],
})
export class UsuarioComponent implements OnInit {

  usuarioFormulario: FormGroup;
  usuarios: Usuario[];
  Estados: Estado[];
  Cidades: Cidade[];
  Sexos: Sexo[];
  _primeiroNomes: Usuario[];
  _primeiroNomesSelecionado: Usuario[];

  //configuração tipo de tela
  tipoTela: any[];
  tipoTelaValue: string = "consultar"; //valor default
    
  UsuariosClonados: { [s: string]: Usuario; } = {};

  loading: boolean = true;

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private estadoService: EstadoService,
    private cidadeService: CidadeService,
    private sexoService: SexoService,
    private messageService: MessageService
  ) {
    this.Formulario();
    this.tipoTela = [
      { label: 'Consultar/Exportar', value: 'consultar' },
      { label: 'Cadastrar', value: 'cadastrar' },
      { label: 'Editar', value: 'editar' }
    ];
  }

  ngOnInit(): void {

    this.CarregarEstados();
    this.CarregarSexos();
    this.CarregarUsuarios();
  }

  CarregarEstados(){
    this.estadoService.getAll().subscribe(
      (estados: Estado[]) => {
        this.Estados = estados;
      },
      (erro: any) => {
        console.log("Erro ao carregar os estados. Erro: " + erro);
      }
    )
  }

  CarregarCidades(){
    this.cidadeService.getId(this.usuarioFormulario.value.Estado.id).subscribe(
      (cidades: Cidade[]) => {
        this.Cidades = cidades;
      },
      (erro: any) => {
        console.log("Erro ao carregar as cidades. Erro: " + erro);
      }
    )
  }

  CarregarSexos() {
    this.sexoService.getAll().subscribe(
      (sexos: Sexo[]) => {
        this.Sexos = sexos;
      },
      (erro: any) => {
        console.log("Erro ao carregar as cidades. Erro: " + erro);
      }
    )
  }

  CarregarUsuarios() {

    this.usuarioService.getAll().subscribe(
      (usuarios: Usuario[]) => {
        this.loading = false;
        this.usuarios = usuarios;
      },
      (erro: any) => {
        console.log("Erro ao carregar os usuarios. Erro: " + erro);
      }
    );
  }

  Formulario(): void {
    this.usuarioFormulario = this.fb.group(
      {
        Id: [0],
        Email: ['', Validators.required],
        Senha: ['', Validators.required],
        PrimeiroNome: ['', Validators.required],
        NomeCompleto: ['', Validators.required],
        Endereco: [''],
        Complemento: [''],
        Numero: [0],
        Cidade: ['', Validators.required],
        Estado: ['', Validators.required],
        Cep: [''],
        Sexo: ['', Validators.required]
      });
  }

  SalvarUsuarioFormularioCadastro() {
    this.usuarioService.post(this.usuarioFormulario.value).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os usuarios.");
      }
    );
  }

  SalvarUsuarioEditado() {
    this.usuarioService.postUsuarios(this.usuarios).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os usuarios.");
      }
    );
  }

  clear(table: Table) {
    table.clear();
  }

  exportPdf() {
    const doc = new jsPDF();
    autoTable(doc, { html: '#TabelaConsultaUsuarios' });
    doc.save('table.pdf');
  }

  exportExcel() {
    import("xlsx").then(xlsx => {
      const worksheet = xlsx.utils.json_to_sheet(this.usuarios);
      const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
      this.saveAsExcelFile(excelBuffer, "usuarios");
    });
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    import("file-saver").then(FileSaver => {
      let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
      let EXCEL_EXTENSION = '.xlsx';
      const data: Blob = new Blob([buffer], {
        type: EXCEL_TYPE
      });
      FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
    });
  }

  onRowEditInit(usuario: Usuario) {
    this.UsuariosClonados[usuario.id] = { ...usuario };
  }

  onRowEditSave(usuario: Usuario, index: number) {
    if (usuario.primeiroNome) {
      delete this.UsuariosClonados[usuario.id];
      this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Usuario editado.' });
    }
    else {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Nome de usuario não encontrado.' });
    }
  }

  onRowEditCancel(usuario: Usuario, index: number) {
    this.usuarios[index] = this.UsuariosClonados[usuario.id];
    delete this.UsuariosClonados[usuario.id];
  }

  EditarUsuarios(usuarios: Usuario) {
    this.usuarioService.putUsuarios(this.usuarios).subscribe(
      (msg) => {
        debugger
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Usuário editado com sucesso.' });
        console.log("Usuário editado com sucesso.");
      },
      (erro: any) => {
        console.log("Erro ao editar o usuário.");
      }
    );
  }
}
