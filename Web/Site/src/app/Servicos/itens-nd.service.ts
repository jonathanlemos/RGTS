import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { NotificacaoDelete } from '../Models/notificacao-delete';
import { NotificacaoPost } from '../Models/notificacao-post';
import { NotificacaoPut } from '../Models/notificacao-put';

@Injectable({
  providedIn: 'root'
})
export class ItensNDService {

  urlBase = `${environment.urlBase}/api/ItensNd`;

  constructor(private http: HttpClient) { }

  GetIdItensNdEDescricaoAlternativa(): Observable<any[]> {
    return this.http.get<any[]>(this.urlBase + "/GetIdItensNdEDescricaoAlternativa");
  };

  PostUploadArquivos(Arquivos:any[]): Observable<any[]> {
    return this.http.get<any[]>(this.urlBase + "/GetIdItensNdEDescricaoAlternativa");
  };
}
