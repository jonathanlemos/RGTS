import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router'
import {
  trigger,
  state,
  style,
  transition,
  animate
} from "@angular/animations";

//models
import { Contrato } from '../Models/Contrato';
//import { Unidade } from '../Models/Unidade';

//services
import { ContratoService } from '../Servicos/Contrato/contrato.service';

//exportar excel/pdf
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

//primeng
import { MultiSelectModule } from 'primeng/multiselect';
import { Table } from 'primeng/table';
import { SelectItem, PrimeNGConfig } from "primeng/api";

@Component({
  selector: 'app-contrato-locacao',
  templateUrl: './contrato-locacao.component.html',
  styleUrls: ['./contrato-locacao.component.css']
})
export class ContratoLocacaoComponent implements OnInit {

  contratoFormulario: FormGroup;
  contratos: Contrato[];
  tipoTela: string;
  unidades: string;
  unidadesSelecionadas: string[];
  classificacoesSelecionadas: string[];
  tipoLocacaoSelecionada: string[];
  nomeFantasiaSelecionada: string[];
  faseSelecionada: string[];
  formaCalculoSelecionado: string[];

  constructor(private fb: FormBuilder, private contratoService: ContratoService, private _route: ActivatedRoute) {
    this.Formulario();
  }

  ngOnInit(): void {

    this._route.queryParams.subscribe(params => {
      this.tipoTela = params['tipoTela'];
    });

    if (this.tipoTela == "consultar" || this.tipoTela == "editar") this.CarregarContratos();

  }

  @ViewChild('primeNgTabelaConsultaContratos') pTableRef: Table;
  ngAfterViewInit() {
    
    // if (this.tipoTela == "consultar" || this.tipoTela == "editar"){
    //   const table = this.pTableRef.el.nativeElement.querySelector('table');
    //   table.setAttribute('id', 'tabelaConsultaContratos');
    // }
  }

  CarregarContratos() {

    this.contratoService.getAll().subscribe(
      (contratos: Contrato[]) => {
        this.contratos = contratos;
      },
      (erro: any) => {
        console.log("Erro ao carregar os contratos. Erro: " + erro);
      }
    );
  }

  Formulario(): void {
    this.contratoFormulario = this.fb.group(
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

  SalvarContratoFormularioCadastro() {
    this.contratoService.post(this.contratoFormulario.value).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os contratos.");
      }
    );
  }

  SalvarContratoEditado() {
    this.contratoService.postContratos(this.contratos).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os contratos.");
      }
    );
  }

  clear(table: Table) {
    table.clear();
  }

  exportPdf() {
    const doc = new jsPDF()
    autoTable(doc, { html: '#tabelaConsultaContratos' })
    doc.save('table.pdf')
  }

  exportExcel() {
    import("xlsx").then(xlsx => {
      const worksheet = xlsx.utils.json_to_sheet(this.contratos);
      const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
      this.saveAsExcelFile(excelBuffer, "contratos");
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
