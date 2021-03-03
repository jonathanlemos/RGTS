import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Estado } from '../../Models/Estado';

@Injectable({
  providedIn: 'root'
})
export class EstadoService {

  urlBase = `${environment.urlBase}/api/estado`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Estado[]> {
    return this.http.get<Estado[]>(this.urlBase);
  };

  getId(id: number): Observable<Estado> {
    return this.http.get<Estado>(this.urlBase + '/' + id);
  };
}
