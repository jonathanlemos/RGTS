import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Entidades/notificacao-delete';
import { NotificacaoPost } from '../../Entidades/notificacao-post';
import { NotificacaoPut } from '../../Entidades/notificacao-put';
import { Usuario } from '../../Entidades/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  urlBase = `${environment.urlBase}/api/usuario`;

  constructor(private http: HttpClient) { }

  getAll() : Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.urlBase + '/GetAll');
  }

  getId(id: number) : Observable<Usuario>{
    return this.http.get<Usuario>(this.urlBase + '/GetId/'+ id);
  }

  //salvar
  post(usuario:Usuario): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, usuario);
  }

  //editar
  put(id:number, usuario: Usuario): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase+'/'+id, usuario);
  }

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  }

}
