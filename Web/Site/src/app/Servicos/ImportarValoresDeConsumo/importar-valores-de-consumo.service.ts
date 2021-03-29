import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Unidade } from '../../Models/Unidade';

@Injectable({
  providedIn: 'root'
})
export class ImportarValoresDeConsumoService {

  urlBase = `${environment.urlBase}/api/usuario`;

  constructor(private http: HttpClient) { }

  //getAll(): Observable<Usuario[]> {
  //  return this.http.get<Usuario[]>(this.urlBase);
  //};

  //getId(id: number): Observable<Usuario> {
  //  return this.http.get<Usuario>(this.urlBase + '/' + id);
  //};

  //salvar
  post(unidade: Unidade): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, unidade);
  };

  ////salvar
  //postUsuarios(usuarios: Usuario[]): Observable<NotificacaoPost> {
  //  return this.http.post<NotificacaoPost>(this.urlBase + '/postUsuarios', usuarios);
  //};

  ////editar
  //put(id: number, usuario: Usuario): Observable<NotificacaoPut> {
  //  return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, usuario);
  //};

  //delete(id: number): Observable<NotificacaoDelete> {
  //  return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  //};

}
