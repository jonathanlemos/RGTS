import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { InstrucaoBoleto } from '../../Models/InstrucaoBoleto';

@Injectable({
  providedIn: 'root'
})
export class InstrucaoBoletoService {

  urlBase = `${environment.urlBase}/api/InstrucaoBoleto`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<InstrucaoBoleto[]> {
    return this.http.get<InstrucaoBoleto[]>(this.urlBase);
  };

}
