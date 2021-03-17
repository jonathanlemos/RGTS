import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { ValoresFaturados } from '../../Models/ValoresFaturados';

@Injectable({
  providedIn: 'root'
})
export class ValoresFaturadosService {

  urlBase = `${environment.urlBase}/api/ValoresFaturados`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ValoresFaturados[]> {
    return this.http.get<ValoresFaturados[]>(this.urlBase);
  };

  getId(id: number): Observable<ValoresFaturados> {
    return this.http.get<ValoresFaturados>(this.urlBase + '/' + id);
  };

  //salvar
  post(valorFaturado: ValoresFaturados): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, valorFaturado);
  };

  //salvar
  postValoresFaturados(valoresFaturados: ValoresFaturados[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase + '/postValoresFaturados', valoresFaturados);
  };

  //editar
  put(id: number, valoresFaturados: ValoresFaturados): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, valoresFaturados);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };
}
