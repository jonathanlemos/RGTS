import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { ContratoLocacao } from '../../Models/contrato-locacao';

@Injectable({
  providedIn: 'root'
})
export class ContratoLocacaoService {

  urlBase = `${environment.urlBase}/api/ContratoLocacao`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ContratoLocacao[]> {
    return this.http.get<ContratoLocacao[]>(this.urlBase);
  };

  getId(id: number): Observable<ContratoLocacao> {
    return this.http.get<ContratoLocacao>(this.urlBase + '/' + id);
  };

  getIdInstrumento(idInstrumento: number): Observable<ContratoLocacao> {
    return this.http.get<ContratoLocacao>(this.urlBase + '/instrumento/' + idInstrumento);
  };

  //salvar
  post(ContratoLocacao: ContratoLocacao): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, ContratoLocacao);
  };

  //salvar
  postContratoLocacoes(contratoLocacoes: ContratoLocacao[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase + '/postContratoLocacaos', contratoLocacoes);
  };

  //editar
  put(id: number, ContratoLocacao: ContratoLocacao): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, ContratoLocacao);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };
}


