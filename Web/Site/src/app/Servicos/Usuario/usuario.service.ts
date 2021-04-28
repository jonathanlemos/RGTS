import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Usuario } from '../../Models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  urlBase = `${environment.urlBase}/api/usuario`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Usuario[]> {
    debugger
    //var reqHeader = new HttpHeaders({ "authorization": localStorage.getItem('token_de_acesso') });
    //var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf8', "authorization": localStorage.getItem('token_de_acesso') });
    //return this.http.get<Usuario[]>(this.urlBase, { headers: reqHeader });
    return this.http.get<Usuario[]>(this.urlBase);
  };

  getId(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(this.urlBase + '/' + id);
  };

  //salvar
  post(usuario: Usuario): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, usuario);
  };

  //salvar
  postUsuarios(usuarios: Usuario[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase+'/postUsuarios', usuarios);
  };

  //editar 1 usuário
  put(id: number, usuario: Usuario): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, usuario);
  };

  //editar lista de usuários
  putUsuarios(usuarios: Usuario[]): Observable<NotificacaoPost> {
    let Pessoa = usuarios;
    return this.http.put<NotificacaoPost>(this.urlBase + '/putUsuarios', Pessoa);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };

}
