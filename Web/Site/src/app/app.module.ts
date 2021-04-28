//angular https://angular.io
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';

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
//import { PasswordModule } from "primeng/password";
import { DividerModule } from "primeng/divider";
import { MenuItem } from 'primeng/api';

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
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';

//autenticacao
import { JwtModule } from '@auth0/angular-jwt';

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
  DividerModule
];

const material = [
  MatBadgeModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatIconModule,
  MatProgressSpinnerModule,
  MatToolbarModule,
  MatSidenavModule,
  MatMenuModule,
  MatInputModule,
  MatCardModule
];

const angularImport = [
  BrowserModule,
  HttpClientModule,
  BrowserAnimationsModule,
  FormsModule,
  ReactiveFormsModule,
  CommonModule
];

const jwt = [
  JwtModule.forRoot({
    config: {
      tokenGetter: function tokenGetter() {
        return localStorage.getItem('token_de_acesso');
      },
      allowedDomains: ["localhost:44370"]
    }
  })
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
    LoginComponent,
    HomeComponent
  ],
  imports: [
    AppRoutingModule,
    NgbModule,
    primeng,
    material,
    angularImport,
    jwt
  ],
  providers: [ConfirmationService, MessageService
    //,LoginService, AuthGuard,
    //{
    //  provide: HTTP_INTERCEPTORS,
    //  useClass: AuthInterceptor,
    //  multi: true
    //}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
