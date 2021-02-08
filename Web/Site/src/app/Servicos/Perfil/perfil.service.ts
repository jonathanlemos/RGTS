import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Perfil } from '../../Models/Perfil';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  urlBase = `${environment.urlBase}/api/perfil`;

  constructor(private http: HttpClient) { }

  //obter todos
  getAll() : Observable<Perfil[]> {
    return this.http.get<Perfil[]>(this.urlBase);
  }

  //obter pelo id
  getId(id: number) : Observable<Perfil>{
    return this.http.get<Perfil>(this.urlBase + '/GetId/'+ id);
  }

  //salvar
  post(perfil:Perfil): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, perfil);
  }

  //editar
  put(id:number, perfil: Perfil): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase+'/'+id, perfil);
  }

  //deletar
  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  }

}
