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

//services
import { ContratoService } from '../Servicos/Contrato/contrato.service';

//exportar excel/pdf
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

//primeng
//import { MultiSelectModule } from 'primeng/multiselect';
import { Table } from 'primeng/table';
import { SelectItem, PrimeNGConfig } from "primeng/api";

@Component({
  selector: 'app-contrato-locacao',
  templateUrl: './contrato-locacao.component.html',
  styleUrls: ['./contrato-locacao.component.css']
})
export class ContratoLocacaoComponent implements OnInit {

  contratoLocacaoFormulario: FormGroup;
  contratos: Contrato[];
  tipoTela: string;
  unidades: string;
  unidadesSelecionadas: string[];
  classificacoesSelecionadas: string[];
  tipoLocacaoSelecionada: string[];
  nomeFantasiaSelecionada: string[];
  faseSelecionada: string[];
  formaCalculoSelecionado: string[];
  virtuais: any[];
  vigentes: any[];
  cobrados: any[];
  excecoes: any[];
  assinados: any[];
  stateOptions: any[];
  value1: string = "off";
  date: Date;

  constructor(private primeNGConfig: PrimeNGConfig, private fb: FormBuilder, private contratoService: ContratoService, private _route: ActivatedRoute) {
    this.Formulario();
    this.CombosPraCarregar();
  }

  CombosPraCarregar() {
    this.virtuais = [
      { name: "Virtuais", value: 1 },
      { name: "Não Virtuais", value: 2 }
    ];

    this.vigentes = [
      { name: "Vigentes", value: 1 },
      { name: "Não Vigentes", value: 2 }
    ];

    this.assinados = [
      { name: "Assinados", value: 1 },
      { name: "Não Assinados", value: 2 }
    ];

    this.cobrados = [
      { name: "Cobrados", value: 1 },
      { name: "Não Cobrados", value: 2 }
    ];

    this.excecoes = [
      { name: "Contrato com Exceção", value: 1 },
      { name: "Contrato sem Exceção", value: 2 }
    ];

  }

  ngOnInit(): void {

    this._route.queryParams.subscribe(params => {
      this.tipoTela = params['tipoTela'];
    });

    //if (this.tipoTela == "consultar" || this.tipoTela == "editar") this.CarregarContratos();

  }

  @ViewChild('primeNgTabelaConsultaContratos') pTableRef: Table;
  ngAfterViewInit() {

    if (this.tipoTela == "consultar" || this.tipoTela == "editar") {
      const table = this.pTableRef.el.nativeElement.querySelector('table');
      table.setAttribute('id', 'tabelaConsultaContratos');
    }
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
    this.contratoLocacaoFormulario = this.fb.group(
      {
        Id: [0],
        unidades: ['', Validators.required],
        classificacao: ['', Validators.required],
        tipoLocacao: ['', Validators.required],
        nomeFantasia: ['', Validators.required],
        fase: ['', Validators.required],
        formaCalculo: ['', Validators.required],
        virtual: ['', Validators.required],
        vigente: ['', Validators.required],
        cobrado: ['', Validators.required],
        excecao: ['', Validators.required], 
        assinado: ['', Validators.required]
      });
  }

  SalvarContratoFormularioCadastro() {
    this.contratoService.post(this.contratoLocacaoFormulario.value).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os contratos.");
      }
    );
  }

  // SalvarContratoEditado() {
  //   this.contratoService.postContratos(this.contratos).subscribe(
  //     (success) => {
  //       console.log("Ok.");
  //     },
  //     (erro: any) => {
  //       console.log("Erro ao carregar os contratos.");
  //     }
  //   );
  // }

  // clear(table: Table) {
  //   table.clear();
  // }

  // exportPdf() {
  //   const doc = new jsPDF()
  //   autoTable(doc, { html: '#tabelaConsultaContratos' })
  //   doc.save('table.pdf')
  // }

  // exportExcel() {
  //   import("xlsx").then(xlsx => {
  //     const worksheet = xlsx.utils.json_to_sheet(this.contratos);
  //     const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
  //     const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
  //     this.saveAsExcelFile(excelBuffer, "contratos");
  //   });
  // }

  // saveAsExcelFile(buffer: any, fileName: string): void {
  //   import("file-saver").then(FileSaver => {
  //     let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
  //     let EXCEL_EXTENSION = '.xlsx';
  //     const data: Blob = new Blob([buffer], {
  //       type: EXCEL_TYPE
  //     });
  //     FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  //   });
  // }
}
