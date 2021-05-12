import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Rubrica } from '../../Models/rubrica';

@Injectable({
  providedIn: 'root'
})
export class RubricaService {

  urlBase = `${environment.urlBase}/api/Rubrica`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Rubrica[]> {
    return this.http.get<Rubrica[]>(this.urlBase);
  };
}
