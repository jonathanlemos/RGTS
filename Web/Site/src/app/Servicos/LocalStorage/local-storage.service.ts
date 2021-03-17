import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  private MesAnoReferencia = "04/2021";
  private storage: Storage;
  private urlBase = `${environment.urlBase}/api/util`;

  constructor(private http: HttpClient) {
    this.storage = window.localStorage;
  }

  ngOnInit(): void {
  }

  CarregarMesAnoReferencia(){
    //let mesano = this.http.get<string>(this.urlBase);
    let mesano = "04/2021";
    this.set("MesAnoReferencia", mesano);
  }

  GetMesAnoReferencia() {
    return this.MesAnoReferencia;
  }

  set(key: string, value: any): boolean {
    if (this.storage) {
      this.storage.setItem(key, JSON.stringify(value));
      return true;
    }
    return false;
  }

  get(key: string): any {
    if (this.storage) {
      return JSON.parse(this.storage.getItem(key));
    }
    return null;
  }

  remove(key: string): boolean {
    if (this.storage) {
      this.storage.removeItem(key);
      return true;
    }
    return false;
  }

  clear(): boolean {
    if (this.storage) {
      this.storage.clear();
      return true;
    }
    return false;
  }

}
