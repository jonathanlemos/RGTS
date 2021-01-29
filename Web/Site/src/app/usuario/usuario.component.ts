import { Component, OnInit, ElementRef, HostListener, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Usuario } from '../Models/Usuario';
import { UsuarioService } from '../Servicos/Usuario/usuario.service';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService, private _route: ActivatedRoute, private eRef: ElementRef)
  {
    this.Formulario();
  }

  ngOnInit(): void {
    
    this._route.queryParams.subscribe(params => {
        this.tipoTela = params['tipoTela'];
    });

    if(this.tipoTela == "consulta") this.CarregarUsuarios();

  }

  public usuarioFormulario: FormGroup;
  public _usuarios : Usuario[];
  public usuarioEditado : Usuario;
  public tipoTela : string;
  public editar: boolean = true;
  public editarIndex: number;

  CarregarUsuarios() {
    this.usuarioService.getAll().subscribe(
      (usuarios: Usuario[]) => {
        this._usuarios = usuarios;
      },
      (erro: any) => {
        console.log("Erro ao carregar os alunos.");
      }
    );
  }

  EditarUsuario($event, i){
    debugger
    this.editar = !this.editar;
    this.editarIndex = i;
    // this.usuarioService.getId(id).subscribe(
    //   (usuario: Usuario) => {
    //     debugger
    //     this._usuario = usuario;
    //   },
    //   (erro: any) => {
    //     console.log("Erro ao carregar os alunos.");
    //   }
    // );  
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

  SalvarUsuarioEditado() {
    debugger
    this.usuarioService.post(this.usuarioEditado).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os alunos.");
      }
    );
  }

  SalvarUsuarioFormularioCadastro() {

    this.usuarioService.post(this.usuarioFormulario.value).subscribe(
      (success) => {
        console.log("Ok.");
      },
      (erro: any) => {
        console.log("Erro ao carregar os alunos.");
      }
    );
  }

  Teste(){
    debugger
  }

  @HostListener('document:click', ['$event'])
  clickout(event) {
    
    //
    if(this.eRef.nativeElement.contains(event.target)) {
      //debugger
      //this.editar = true;
    } else {
      debugger
      //this.SalvarUsuarioEditado();
    }
  }

}
