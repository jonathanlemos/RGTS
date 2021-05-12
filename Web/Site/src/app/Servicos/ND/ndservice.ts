import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { ND } from '../../Models/ND';
import { map } from "rxjs/operators";
import { Content } from '@angular/compiler/src/render3/r3_ast';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NDService {

  urlBase = `${environment.urlBase}/api/ND`;

  constructor(private http: HttpClient, private router: Router) { }

  getAll(): Observable<ND[]> {
    return this.http.get<ND[]>(this.urlBase);
  };

  getId(id: number): Observable<ND> {
    return this.http.get<ND>(this.urlBase + '/' + id);
  };

  //salvar
  post(nd: ND): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase, nd);
  };

  //editar
  put(id: number, nd: ND): Observable<NotificacaoPut> {
    return this.http.put<NotificacaoPut>(this.urlBase + '/' + id, nd);
  };

  delete(id: number): Observable<NotificacaoDelete> {
    return this.http.delete<NotificacaoDelete>(this.urlBase + '/' + id);
  };

  filter(nd: ND): Observable<ND[]> {
    return this.http.post<ND[]>(this.urlBase + '/filtro', nd);
  };

  //salvar
  gerarBoletos(nds: number[]): Observable<NotificacaoPost> {
    return this.http.post<NotificacaoPost>(this.urlBase + '/boletos', nds);
  }

  //salvar
  gerarArquivoRemessa(idServico: number, idMensagem: number, idInstrucao: number, nds: ND[]): Observable<any> {
    let fileExtension = 'text/plain';
    let input = '.txt';

    return this.http.post(this.urlBase + '/gerarArquivoRemessa/' + idServico + '/mensagem/' + idMensagem + '/instrucao/' + idInstrucao, nds, {
      responseType: 'blob',
      observe: 'response'
    })
      .pipe(
        map((res: any) => {
          let data = {
            file: new Blob([res.body], { type: fileExtension }),
            filename: res.headers.get('content-disposition').split(';')[1].split('filename')[1].split('=')[1].trim()
          }
          return data;
        })
      );
  };

  visualizarNds(nds: number[]) {
    this.router.navigate(['/visualizarNds'], { queryParams: { dados: nds } });
  }
}
