import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificacaoPost } from '../Models/notificacao-post';
import { PermissaoServiceService } from '../Servicos/Permissao/permissao.service';

@Component({
  selector: 'app-cadastro-permissao',
  templateUrl: './cadastro-permissao.component.html',
  styleUrls: ['./cadastro-permissao.component.css']
})
export class CadastroPermissaoComponent implements OnInit {

  constructor(private fb: FormBuilder, private permissaoService:PermissaoServiceService ) { 
    this.Formulario();
  }

  ngOnInit(): void {
  }

  public permissaoFormulario : FormGroup;

  Formulario(){
    this.permissaoFormulario = this.fb.group(
      {
        Id: [0],
        Nome: ['', Validators.required],
        Descricao: ['', Validators.required],
        ListaPermissao: []
      });
  }

  SalvarPermissao() {

    this.permissaoService.post(this.permissaoFormulario.value).subscribe(
      (notificacao:NotificacaoPost) => {
        console.log(notificacao.Mensagem);
      },
      (erro: any) => 
      {
        console.log("Erro ao salvar a permissao: " + erro);
      }
    );
  }

}
