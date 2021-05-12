import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { ItensND } from '../../Models/ItensND';

@Injectable({
  providedIn: 'root'
})
export class ItensNDService {

  urlBase = `${environment.urlBase}/api/ItensNd`;

  constructor(private http: HttpClient) { }

  //salvar
  post(itensNd: ItensND[]): Observable<NotificacaoPost> {
    debugger
    return this.http.post<NotificacaoPost>(this.urlBase, itensNd);
  };
}
