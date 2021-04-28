import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  readonly urlBase = `${environment.urlBase}/api/LoginPessoa`;

  constructor(private http: HttpClient, private router: Router) { }

  //registerUser(usuario: LoginUsuario) {
  //  const body: LoginUsuario = {
  //    nomeCompleto: usuario.nomeCompleto,
  //    senha: usuario.senha,
  //    email: usuario.email,
  //    primeiroNome: usuario.primeiroNome
  //  }
  //  var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
  //  return this.http.post(this.rootUrl + '/api/Login/Register', body, { headers: reqHeader });
  //}

  AutenticarERedirecionarHome(login, senha): any {
    let data = { "LoginAcesso": login, "Senha": senha };
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf8', 'No-Auth': 'True' });
    this.http.post(this.urlBase + '/ValidarAcesso', data, { headers: reqHeader }).subscribe((data: any) => {
      localStorage.setItem('token_de_acesso', data.token);
      this.router.navigate(['/home']);
    },
      (err: HttpErrorResponse) => {
        return err;
      });
  }

  Desconectar() {
    localStorage.removeItem('token_de_acesso');
  }

  EstaLogado(): boolean {
    return localStorage.getItem('token_de_acesso') !== null;
  }

  GetUserClaims() {
    return this.http.get(this.urlBase + '/api/GetUserClaims');
  }
}
