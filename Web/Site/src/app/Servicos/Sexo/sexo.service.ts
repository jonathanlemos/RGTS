import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Sexo } from '../../Models/sexo';

@Injectable({
  providedIn: 'root'
})
export class SexoService {

  urlBase = `${environment.urlBase}/api/sexo`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Sexo[]> {
    return this.http.get<Sexo[]>(this.urlBase);
  };

  getId(id: number): Observable<Sexo> {
    return this.http.get<Sexo>(this.urlBase + '/' + id);
  };
}
