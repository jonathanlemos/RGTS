import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioComponent } from './usuario/usuario.component';
import { PerfilComponent } from './perfil/perfil.component';
import { PermissaoComponent } from './permissao/permissao.component';
import { ConfigurarPerfilComponent } from './configurar-perfil/configurar-perfil.component';
import { ContratoLocacaoComponent } from './contrato-locacao/contrato-locacao.component';
import { UnidadeComponent } from './unidade/unidade.component';
import { ImportarValoresDeConsumoComponent } from './importar-valores-de-consumo/importar-valores-de-consumo.component';

const routes: Routes = [
  { path: 'usuario', component: UsuarioComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: 'permissao', component: PermissaoComponent },
  { path: 'configurarPerfil', component: ConfigurarPerfilComponent },
  { path: 'contratoLocacao', component: ContratoLocacaoComponent },
  { path: 'unidade', component: UnidadeComponent },
  { path: 'importarValoresDeConsumo', component: ImportarValoresDeConsumoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
