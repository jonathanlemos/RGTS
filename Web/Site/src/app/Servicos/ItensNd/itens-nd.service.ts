import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { NotificacaoDelete } from '../../Models/notificacao-delete';
import { NotificacaoPost } from '../../Models/notificacao-post';
import { NotificacaoPut } from '../../Models/notificacao-put';
import { ItensND } from '../../Models/ItensND';
import { ImportarValoresDeConsumoModel } from '../../Models/importar-valores-de-consumo-model';

@Injectable({
  providedIn: 'root'
})
export class ItensNDService {

  urlBase = `${environment.urlBase}/api/ItensNd`;

  constructor(private http: HttpClient) { }

  //salvar
  post(importarValoresDeConsumoModel: ImportarValoresDeConsumoModel[]): Observable<NotificacaoPost> {
    debugger
    let itens = [];
    for (let i = 0; i < importarValoresDeConsumoModel.length; i++) {
      let _itens = new ImportarValoresDeConsumoModel();
      _itens.luc.nomeLuc = importarValoresDeConsumoModel[i].luc.nomeLuc;
      _itens.valoresFaturado.valorFaturado = Number(importarValoresDeConsumoModel[i].valoresFaturado.valorFaturado);
      _itens.rubrica.id = importarValoresDeConsumoModel[i].rubrica.id;
      itens.push(_itens);
    }
    debugger
    return this.http.post<NotificacaoPost>(this.urlBase, itens);
  };
}
