import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { MenuSuperiorComponent } from './menu-superior/menu-superior.component';
import { CadastroPerfilComponent } from './cadastro-perfil/cadastro-perfil.component';
import { CadastroPermissaoComponent } from './cadastro-permissao/cadastro-permissao.component';

const routes: Routes = [
  { path: 'MenuSuperior', component: MenuSuperiorComponent },
  { path: 'cadastrousuario', component: CadastroUsuarioComponent },
  { path: 'cadastroperfil', component: CadastroPerfilComponent },
  { path: 'cadastropermissao', component: CadastroPermissaoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }