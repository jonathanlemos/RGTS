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
import { ValoresFaturados } from '../Models/ValoresFaturados';

//services
import { ValoresFaturadosService } from '../Servicos/ValoresFaturados/valoresfaturados.service';

//exportar excel/pdf
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

//primeng
//import { MultiSelectModule } from 'primeng/multiselect';
import { Table } from 'primeng/table';
import { InputMaskModule } from 'primeng/inputmask';
import { SelectItem, PrimeNGConfig } from "primeng/api";

@Component({
  selector: 'app-valoreslojistaempreendedor',
  templateUrl: './valoreslojistaempreendedor.component.html',
  styleUrls: ['./valoreslojistaempreendedor.component.css']
})

export class ValoreslojistaempreendedorComponent implements OnInit {

  valoresFaturadosFormulario: FormGroup;
  valoresFaturados: ValoresFaturados[];
  tipoTela: string;
  tipoLocacaoSelecionada: string[];
  unidadesSelecionadas: string[];
  nomeFantasiaSelecionada: string[];
  val3: string;

  constructor(private primeNGConfig: PrimeNGConfig, private fb: FormBuilder, private valoresFaturadosService: ValoresFaturadosService, private _route: ActivatedRoute) {
    this.Formulario();
  }

  ngOnInit(): void {
    this._route.queryParams.subscribe(params => {
      this.tipoTela = params['tipoTela'];
    });
  }

  Formulario(): void {
    this.valoresFaturadosFormulario = this.fb.group(
      {
        Id: [0],
        unidades: ['', Validators.required],
        tipoLocacao: ['', Validators.required],
        nomeFantasia: ['', Validators.required],
        mesAnoProcDe: ['', Validators.required]
      });
  }
}
