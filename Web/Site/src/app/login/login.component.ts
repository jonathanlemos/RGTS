import { Input, Component, Output, EventEmitter, OnInit } from '@angular/core';
import { LoginService } from '../Servicos/Login/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Input() error: string | null;
  loginPessoa: string;
  senhaPessoa: string;
  constructor(private loginService: LoginService) { }

  ngOnInit() {

  }

  Login() {
    this.loginService.AutenticarERedirecionarHome(this.loginPessoa, this.senhaPessoa);
  }

}
