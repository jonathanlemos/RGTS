//angular
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

//bootstrap
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

//primeNG
import { AccordionModule } from 'primeng/accordion';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';
import {ListboxModule} from 'primeng/listbox';

//components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PerfilComponent } from './perfil/perfil.component';
import { PermissaoComponent } from './permissao/permissao.component';

//dashboard
import { MenuSuperiorComponent } from './dashboard/menu-superior/menu-superior.component';
import { UsuarioMenuComponent } from './dashboard/usuario-menu/usuario-menu.component';
import { ConfigurarPerfilComponent } from './configurar-perfil/configurar-perfil.component';
import { ConfigurarPermissaoComponent } from './configurar-permissao/configurar-permissao.component';
import { PerfilMenuComponent } from './dashboard/perfil-menu/perfil-menu.component';

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
    PerfilMenuComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    AccordionModule,
    TableModule,
    ButtonModule,
    MultiSelectModule,
    ListboxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
