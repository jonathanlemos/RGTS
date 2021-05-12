//angular https://angular.io
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

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
import { ConfirmationService, MessageService } from 'primeng/api';
import { AccordionModule } from 'primeng/accordion';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { MultiSelectModule } from 'primeng/multiselect';
import { ListboxModule } from 'primeng/listbox';
import { CascadeSelectModule } from 'primeng/cascadeselect';
import { SelectButtonModule } from 'primeng/selectbutton';
import { CalendarModule } from 'primeng/calendar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToolbarModule } from 'primeng/toolbar';
import { FileUploadModule } from 'primeng/fileupload';
import { DialogModule } from 'primeng/dialog';
import { InputMaskModule } from 'primeng/inputmask';
import { ToastModule } from 'primeng/toast';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { SidebarModule } from 'primeng/sidebar';

//components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { PerfilComponent } from './perfil/perfil.component';
import { PermissaoComponent } from './permissao/permissao.component';
import { ConfigurarPerfilComponent } from './configurar-perfil/configurar-perfil.component';
import { ConfigurarPermissaoComponent } from './configurar-permissao/configurar-permissao.component';
import { MenuComponent } from './menu/menu.component';
import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { ContratoLocacaoComponent } from './contrato-locacao/contrato-locacao.component';
import { UnidadeComponent } from './unidade/unidade.component';
import { ImportarValoresDeConsumoComponent } from './importar-valores-de-consumo/importar-valores-de-consumo.component';
import { ValoresFaturadosComponent } from './valores-faturados/valores-faturados.component';
import { CobrarNdsComponent } from './cobrar-nds/cobrar-nds.component';
import { EmitirNdsComponent } from './emitir-nds/emitir-nds.component';
import { VisualizarNdsComponent } from './visualizar-nds/visualizar-nds.component';

const primeng = [
  AccordionModule,
  TableModule,
  ButtonModule,
  MultiSelectModule,
  ListboxModule,
  CascadeSelectModule,
  SelectButtonModule,
  CalendarModule,
  ConfirmDialogModule,
  ToolbarModule,
  FileUploadModule,
  DialogModule,
  InputMaskModule,
  DropdownModule,
  ToastModule,
  RadioButtonModule,
  SidebarModule
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

const angularImport = [
  BrowserModule,
  HttpClientModule,
  BrowserAnimationsModule,
  FormsModule,
  ReactiveFormsModule,
  CommonModule
];

@NgModule({
  declarations: [
    AppComponent,
    UsuarioComponent,
    PerfilComponent,
    PermissaoComponent,
    ConfigurarPerfilComponent,
    ConfigurarPermissaoComponent,
    MenuComponent,
    CabecalhoComponent,
    ContratoLocacaoComponent,
    UnidadeComponent,
    ImportarValoresDeConsumoComponent,
    ValoresFaturadosComponent,
    CobrarNdsComponent,
    EmitirNdsComponent,
    VisualizarNdsComponent
  ],
  imports: [
    AppRoutingModule,
    NgbModule,
    primeng,
    material,
    angularImport
  ],
  providers: [ConfirmationService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
