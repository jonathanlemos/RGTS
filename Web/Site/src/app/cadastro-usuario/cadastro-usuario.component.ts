import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Usuario } from '../Models/Usuario';
import { UsuarioService } from '../Servicos/Usuario/usuario.service';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.css']
})
export class CadastroUsuarioComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService)
  {
    this.Formulario();
  }

  ngOnInit(): void {
    //this.carregarUsuarios();
  }

  public usuarioFormulario: FormGroup;
  public _usuarios : Usuario[];

  CarregarUsuarios() {
    debugger
    this.usuarioService.getAll().subscribe(
      (usuarios: Usuario[]) => {
        this._usuarios = usuarios;
      },
      (erro: any) => {
        console.log("Erro ao carregar os alunos.");
      }
    );
  }

  Formulario() {
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

  SalvarUsuario() {

    this.usuarioService.post(this.usuarioFormulario.value).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os alunos.");
      }
    );
  }

}
