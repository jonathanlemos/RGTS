import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ImportarValoresDeConsumoModel } from '../../Models/importar-valores-de-consumo-model';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { Unidade } from '../../Models/Unidade';

@Injectable({
  providedIn: 'root'
})
export class ImportarValoresDeConsumoService {

  urlBase = `${environment.urlBase}/api/importarValoresDeConsumo`;

  constructor(private http: HttpClient) { }

  //getAll(): Observable<Usuario[]> {
  //  return this.http.get<Usuario[]>(this.urlBase);
  //};

  //getId(id: number): Observable<Usuario> {
  //  return this.http.get<Usuario>(this.urlBase + '/' + id);
  //};

  //salvar
  post(dadosImportacao: ImportarValoresDeConsumoModel[]): Observable<NotificacaoPost> {
    debugger

    try {
      return this.http.post<NotificacaoPost>(this.urlBase, dadosImportacao);
    } catch (error) {
      debugger
    }
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
