import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PerfilService } from '../Servicos/Perfil/perfil.service';

@Component({
  selector: 'app-cadastro-perfil',
  templateUrl: './cadastro-perfil.component.html',
  styleUrls: ['./cadastro-perfil.component.css']
})
export class CadastroPerfilComponent implements OnInit {

  constructor(private fb: FormBuilder, private perfilService:PerfilService ) { 
    this.Formulario();
  }

  ngOnInit(): void {

  }

  public perfilFormulario : FormGroup;

  Formulario(){
    this.perfilFormulario = this.fb.group(
      {
        Id: [0],
        Nome: ['', Validators.required],
        Descricao: ['', Validators.required],
        ListaPermissao: []
      });
  }

  SalvarPerfil() {

    this.perfilService.post(this.perfilFormulario.value).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao salvar o perfil.");
      }
    );
  }

}
