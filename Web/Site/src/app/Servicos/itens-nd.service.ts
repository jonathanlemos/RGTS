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

  GetIdItensNdEDescricaoAlternativa(): Observable<ItensNDServiceModel[]> {
    return this.http.get<ItensNDServiceModel[]>(this.urlBase + "/GetIdItensNdEDescricaoAlternativa");
  };
}

export class ItensNDServiceModel {
  id: number;
  descricaoAlternativa: string;
  //idShopping: number;
  //idND: number;
  //valorSaldoRubrica:number;
  //valorPrincipalRubrica: number;
  //valorOriginalRubrica: number;
  //idItemRubrica: number;
  //idDescricaoAlternativa: number;
  //anoCompetencia: number;
  //mesCompetencia: number;
  //eNegociado:boolean;
  //numeroNegociacao: number;
  //usuario:string;
  //dataInsercao:Date;
  //usuarioAlteracao: string;
  //dataAlteracao: Date

}
