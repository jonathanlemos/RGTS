import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Marca } from '../../Models/Marca';

@Injectable({
  providedIn: 'root'
})
export class MarcaService {
  urlBase = `${environment.urlBase}/api/Marca`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Marca[]> {
    return this.http.get<Marca[]>(this.urlBase);
  };

  getId(id: number): Observable<Marca> {
    return this.http.get<Marca>(this.urlBase + '/' + id);
  };

  //salvar
  post(marca: Marca): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, marca);
  };

  //salvar
  postMarcas(marcas: Marca[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase + '/postValoresFaturados', marcas);
  };

  //editar
  put(id: number, marca: Marca): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, marca);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };
}
