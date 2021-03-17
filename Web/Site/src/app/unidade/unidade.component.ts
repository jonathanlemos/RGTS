//angular
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-unidade',
  templateUrl: './unidade.component.html',
  styleUrls: ['./unidade.component.css']
})
export class UnidadeComponent implements OnInit {

  unidadeFormulario: FormGroup;

  //configuração tipo de tela  
  tipoTela: any[];
  tipoTelaValue: string = "cadastrar"; //valor default

  //select multiple
  niveis: string;
  nivelSelecionado: string[];

  localizacoes: string;
  localizacaoSelecionado: string[];

  fases: string;
  faseSelecionado: string[];

  empreendimentos: string;
  empreendimentoSelecionado: string[];

  empreendimentosParaAluguel: string;
  empreendimentoParaAluguelSelecionado: string[];

  classificacoes: string;
  classificacaoSelecionado: string[];

  ramos: string;
  ramoSelecionado: string[];

  atividades: string;
  AtividadeSelecionado: string[];

  constructor(private fb: FormBuilder) {
    this.Formulario();

    //carrega tela de consultar/cadastrar/editar
    this.tipoTela = [{ label: 'Consultar', value: 'consultar' }, { label: 'Cadastrar', value: 'cadastrar' }];


    //this.CombosPraCarregar();
  }

  

  ngOnInit(): void {
  }

  Formulario(): void {
    this.unidadeFormulario = this.fb.group(
      {
        CodigoUnidadeForm: ['', Validators.required],
        nivelForm: ['', Validators.required],
        localizacaoForm: ['', Validators.required],
        faseForm: ['', Validators.required],
        empreendimentoForm: ['', Validators.required],
        empreendimentoParaAluguelForm: ['', Validators.required],
        ramoForm: ['', Validators.required],
        atividadeForm: ['', Validators.required],
        QTDCRDForm: ['', Validators.required],
        potenciaFanCoilForm: ['', Validators.required],
        cargaForm: ['', Validators.required],
        qtdm2InauguracaoForm: ['', Validators.required],
        qtdm2ablForm: ['', Validators.required],
        qtdm2LocavelComReducaoForm: ['', Validators.required]
      });
  }

}
