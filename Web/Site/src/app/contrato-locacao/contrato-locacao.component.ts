import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

//models
import { Contrato } from '../Models/Contrato';

//services
import { ContratoService } from '../Servicos/Contrato/contrato.service';
import { LocalStorageService } from '../Servicos/LocalStorage/local-storage.service';

@Component({
  selector: 'app-contrato-locacao',
  templateUrl: './contrato-locacao.component.html',
  styleUrls: ['./contrato-locacao.component.css']
})
export class ContratoLocacaoComponent implements OnInit {

  contratoLocacaoFormulario: FormGroup;
  contratos: Contrato[];

  //configuração tipo de tela  
  tipoTela:      any[];
  tipoTelaValue: string = "cadastrar"; //valor default

  //campos formulário  
  unidadesSelecionadas:       string[];
  classificacoesSelecionadas: string[];
  tipoLocacaoSelecionada:     string[];
  nomeFantasiaSelecionada:    string[];
  faseSelecionada:            string[];
  formaCalculoSelecionado:    string[];
  virtuaisSelecionado:        string[];
  assinadoSelecionado:        string[];
  vigentesSelecionado:        string[];
  cobradoSelecionado:         string[];
  excecaoSelecionado:         string[];

  //select combos formulário
  unidades:       string;
  classificacao:  string;
  tipoLocacao:    string;
  nomeFantasia:   string;
  fase:           string;
  formaCalculo:   string;
  virtuais:       any[];
  vigentes:       any[];
  cobrados:       any[];
  excecoes:       any[];
  assinados:      any[];

  //calendário formulário
  dtAssinaturaInicio:   Date;
  dtAssinaturaFim:      Date;
  dtInicioDaVigencia:   Date;
  dtFimDaVigencia:      Date;

  mesteste: string;

  constructor(private localStorageService: LocalStorageService, private fb: FormBuilder, private contratoService: ContratoService) {
    this.Formulario();
    this.CombosTela();

    this.tipoTela = [{ label: 'Consultar', value: 'consultar' }, { label: 'Cadastrar', value: 'cadastrar' }];
    this.getteste();
  }

  getteste() {
    this.mesteste = this.localStorageService.get("MesAnoReferencia");
  }

  ngOnInit() {

  }

  CombosTela() {

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
        Id: [],
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
        assinado: ['', Validators.required],
        dtAssinaturaInicio: ['', Validators.required],
        dtAssinaturaFim: ['', Validators.required],
        dtInicioDaVigencia: ['', Validators.required],
        dtFimDaVigencia: ['', Validators.required]
      });
  }

  SalvarContrato() {
    this.contratoService.post(this.contratoLocacaoFormulario.value).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os contratos.");
      }
    );
  }

}
