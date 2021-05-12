import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { TipoInstrumento } from '../../Models/TipoInstrumento';

@Injectable({
  providedIn: 'root'
})
export class TipoInstrumentoService {
  urlBase = `${environment.urlBase}/api/TipoInstrumento`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<TipoInstrumento[]> {
    return this.http.get<TipoInstrumento[]>(this.urlBase);
  };

  getId(id: number): Observable<TipoInstrumento> {
    return this.http.get<TipoInstrumento>(this.urlBase + '/' + id);
  };

  //salvar
  post(tipoInstrumento: TipoInstrumento): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, tipoInstrumento);
  };

  //salvar
  postTiposInstrumentos(tiposInstrumentos: TipoInstrumento[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase + '/postValoresFaturados', tiposInstrumentos);
  };

  //editar
  put(id: number, tipoInstrumento: TipoInstrumento): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, tipoInstrumento);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };
}
