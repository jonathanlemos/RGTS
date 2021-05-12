import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Luc } from '../../Models/Luc';

@Injectable({
  providedIn: 'root'
})
export class LucService {
  urlBase = `${environment.urlBase}/api/Luc`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Luc[]> {
    return this.http.get<Luc[]>(this.urlBase);
  };

  getId(id: number): Observable<Luc> {
    return this.http.get<Luc>(this.urlBase + '/' + id);
  };

  //salvar
  post(luc: Luc): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, luc);
  };

  //salvar
  postLucs(lucs: Luc[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase + '/postValoresFaturados', lucs);
  };

  //editar
  put(id: number, luc: Luc): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, luc);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };
}
