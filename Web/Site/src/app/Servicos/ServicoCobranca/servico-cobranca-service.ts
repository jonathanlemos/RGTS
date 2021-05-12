import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ServicoCobranca } from '../../Models/ServicoCobranca';

@Injectable({
  providedIn: 'root'
})
export class ServicoCobrancaService {

  urlBase = `${environment.urlBase}/api/ServicoCobranca`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ServicoCobranca[]> {
    return this.http.get<ServicoCobranca[]>(this.urlBase);
  };

}
