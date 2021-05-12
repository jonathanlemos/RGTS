import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { ContratoLucs } from '../../Models/contrato-lucs';

@Injectable({
  providedIn: 'root'
})
export class ContratoLucsService {

  urlBase = `${environment.urlBase}/api/ContratoLucs`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ContratoLucs[]> {
    return this.http.get<ContratoLucs[]>(this.urlBase);
  };

  getId(id: number): Observable<ContratoLucs> {
    return this.http.get<ContratoLucs>(this.urlBase + '/' + id);
  };

  getInstrumentoIdByLucId(idLuc: number): Observable<ContratoLucs> {
    return this.http.get<ContratoLucs>(this.urlBase + '/luc/' + idLuc);
  };

  getLucIdByInstrumentoId(idInstrumento: number): Observable<ContratoLucs> {
    return this.http.get<ContratoLucs>(this.urlBase + '/instrumento/' + idInstrumento);
  };

  //salvar
  post(contratoLucs: ContratoLucs): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, contratoLucs);
  };

  //salvar
  postContratoLocacoes(contratoLucs: ContratoLucs[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase + '/postContratoLocacaos', contratoLucs);
  };

  //editar
  put(id: number, ContratoLucs: ContratoLucs): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, ContratoLucs);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };
}


