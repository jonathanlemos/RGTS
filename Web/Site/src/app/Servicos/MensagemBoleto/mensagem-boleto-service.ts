import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { MensagemBoleto } from '../../Models/MensagemBoleto';

@Injectable({
  providedIn: 'root'
})
export class MensagemBoletoService {

  urlBase = `${environment.urlBase}/api/MensagemBoleto`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<MensagemBoleto[]> {
    return this.http.get<MensagemBoleto[]>(this.urlBase);
  };

}
