import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { MenuSuperiorComponent } from './menu-superior/menu-superior.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CadastroPerfilComponent } from './cadastro-perfil/cadastro-perfil.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastroUsuarioComponent,
    MenuSuperiorComponent,
    CadastroPerfilComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
