import { Component, OnInit } from '@angular/core';
import { LoginService } from './Servicos/Login/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'RGTS';
  estaLogado = false;
  constructor(private loginService: LoginService) { }

  ngOnInit() {
    this.estaLogado = this.loginService.EstaLogado();
  }

}
