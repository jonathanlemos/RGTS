import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router'

import { Usuario } from '../Models/Usuario';
import { UsuarioService } from '../Servicos/Usuario/usuario.service';

import { Table } from 'primeng/table';

import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService,
    private _route: ActivatedRoute) {
    this.Formulario();

  }

  ngOnInit(): void {

    this._route.queryParams.subscribe(params => {
      this.tipoTela = params['tipoTela'];
    });

    if (this.tipoTela == "consultar" || this.tipoTela == "editar") this.CarregarUsuarios();

  }

  @ViewChild('primeNgTabelaConsultaUsuarios') pTableRef: Table;
  ngAfterViewInit() {
    
    if (this.tipoTela == "consultar" || this.tipoTela == "editar"){
      const table = this.pTableRef.el.nativeElement.querySelector('table');
      table.setAttribute('id', 'tabelaConsultaUsuarios');
    }
  }

  usuarioFormulario: FormGroup;
  usuarios: Usuario[];
  tipoTela: string;
  loading: boolean = true;
  _primeiroNomes: Usuario[];
  _primeiroNomesSelecionado: Usuario[];

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
        Sexo: [0, Validators.required]
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
    const doc = new jsPDF()
    autoTable(doc, { html: '#tabelaConsultaUsuarios' })
    doc.save('table.pdf')
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
}
