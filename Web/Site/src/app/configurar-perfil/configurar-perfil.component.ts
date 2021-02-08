import { Component, OnInit } from '@angular/core';
import { Perfil } from '../Models/Perfil';
import { PrimeNGConfig } from "primeng/api";
import { PerfilService } from '../Servicos/Perfil/perfil.service';
import { Usuario } from '../Models/Usuario';
import { UsuarioService } from '../Servicos/Usuario/usuario.service';

@Component({
  selector: 'app-configurar-perfil',
  templateUrl: './configurar-perfil.component.html',
  styleUrls: ['./configurar-perfil.component.css']
})
export class ConfigurarPerfilComponent implements OnInit {

  constructor(private perfilService: PerfilService, private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.CarregarPerfis();
    this.CarregarUsuarios();
  }

  perfis: Perfil[];
  perfilSelecionado: Perfil;

  usuarios: Usuario[];
  usuarioSelecionado: Usuario;

  CarregarUsuarios(){
    this.usuarioService.getAll().subscribe(
      (usuarios: Usuario[]) => {
        this.usuarios = usuarios;
      },
      (error:any)=>{
        console.log('Erro ao carregar os perfis: ' + error);
      }
    )
  }

  CarregarPerfis(){
    this.perfilService.getAll().subscribe(
      (_perfis: Perfil[]) => {
        this.perfis = _perfis;
      },
      (error:any)=>{
        console.log('Erro ao carregar os perfis: ' + error);
      }
    )
  }

}
