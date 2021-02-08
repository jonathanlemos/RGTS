import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Permissao } from '../../Models/Permissao';

@Injectable({
  providedIn: 'root'
})
export class PermissaoServiceService {

  urlBase = `${environment.urlBase}/api/permissao`;

  constructor(private http: HttpClient) { }

  //obter todos
  getAll() : Observable<Permissao[]> {
    return this.http.get<Permissao[]>(this.urlBase);
  }

  //obter pelo id
  getId(id: number) : Observable<Permissao>{
    return this.http.get<Permissao>(this.urlBase + '/GetId/'+ id);
  }

  //salvar
  post(permissao:Permissao): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, permissao);
  }

  //editar
  put(id:number, permissao: Permissao): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase+'/'+id, permissao);
  }

  //deletar
  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  }

}
