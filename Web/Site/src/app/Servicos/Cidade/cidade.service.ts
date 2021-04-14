import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Cidade } from '../../Models/Cidade';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  urlBase = `${environment.urlBase}/api/cidade`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Cidade[]> {
    return this.http.get<Cidade[]>(this.urlBase);
  };

  getId(id: number): Observable<Cidade[]> {
    debugger
    return this.http.get<Cidade[]>(this.urlBase + '/' + id);
  };
}
