import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { MenuSuperiorComponent } from './menu-superior/menu-superior.component';
import { CadastroPerfilComponent } from './cadastro-perfil/cadastro-perfil.component';

const routes: Routes = [
  { path: 'cadastrousuario', component: CadastroUsuarioComponent },
  { path: 'cadastroperfil', component: CadastroPerfilComponent },
  { path: 'MenuSuperior', component: MenuSuperiorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
