import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Contrato } from '../../Models/Contrato';

@Injectable({
  providedIn: 'root'
})
export class ContratoService {

  urlBase = `${environment.urlBase}/api/Contrato`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Contrato[]> {
    return this.http.get<Contrato[]>(this.urlBase);
  };

  getId(id: number): Observable<Contrato> {
    return this.http.get<Contrato>(this.urlBase + '/' + id);
  };

  //salvar
  post(Contrato: Contrato): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, Contrato);
  };

  //salvar
  postContratos(contratos: Contrato[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase+'/postContratos', contratos);
  };

  //editar
  put(id: number, Contrato: Contrato): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, Contrato);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };
}


