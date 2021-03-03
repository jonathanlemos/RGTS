//angular https://angular.io
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

//angular material https://material.angular.io
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatMenuModule } from '@angular/material/menu';

//bootstrap https://ng-bootstrap.github.io/#/home
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

//primeNG https://primefaces.org/primeng
import { AccordionModule } from 'primeng/accordion';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';
import { ListboxModule } from 'primeng/listbox';
import { CascadeSelectModule } from 'primeng/cascadeselect';
import { SelectButtonModule } from 'primeng/selectbutton';

//components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { PerfilComponent } from './perfil/perfil.component';
import { PermissaoComponent } from './permissao/permissao.component';

//dashboard
import { MenuSuperiorComponent } from './dashboard/menu-superior/menu-superior.component';
import { UsuarioMenuComponent } from './dashboard/usuario-menu/usuario-menu.component';
import { ConfigurarPerfilComponent } from './configurar-perfil/configurar-perfil.component';
import { ConfigurarPermissaoComponent } from './configurar-permissao/configurar-permissao.component';
import { PerfilMenuComponent } from './dashboard/perfil-menu/perfil-menu.component';
import { MenuComponent } from './menu/menu.component';
import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { ContratoComponent } from './contrato/contrato.component';
import { ContratoLocacaoComponent } from './contrato-locacao/contrato-locacao.component';
import { UnidadeComponent } from './unidade/unidade.component';

const primeng = [
  AccordionModule,
  TableModule,
  ButtonModule,
  MultiSelectModule,
  ListboxModule,
  CascadeSelectModule,
  SelectButtonModule
];

const material = [
  MatBadgeModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatIconModule,
  MatProgressSpinnerModule,
  MatToolbarModule,
  MatSidenavModule,
  MatMenuModule
];

@NgModule({
  declarations: [
    AppComponent,
    UsuarioComponent,
    MenuSuperiorComponent,
    PerfilComponent,
    PermissaoComponent,
    UsuarioMenuComponent,
    ConfigurarPerfilComponent,
    ConfigurarPermissaoComponent,
    PerfilMenuComponent,
    MenuComponent,
    CabecalhoComponent,
    ContratoComponent,
    ContratoLocacaoComponent,
    UnidadeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    primeng,
    material
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
