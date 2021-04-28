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

  urlBase = `${environment.urlBase}/api/Contrato`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ContratoLocacao[]> {
    return this.http.get<ContratoLocacao[]>(this.urlBase);
  };

  getId(id: number): Observable<ContratoLocacao> {
    return this.http.get<ContratoLocacao>(this.urlBase + '/' + id);
  };

  //salvar
  post(Contrato: ContratoLocacao): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, Contrato);
  };

  //salvar
  postContratos(contratos: ContratoLocacao[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase + '/postContratos', contratos);
  };

  //editar
  put(id: number, Contrato: ContratoLocacao): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, Contrato);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };
}
