import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
//import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';

@Injectable({
  providedIn: 'root'
})
export class ServiceRGTSService {

  //@Injectable()
  //constructor(private http: HttpClient) { }
  constructor() { }
}
