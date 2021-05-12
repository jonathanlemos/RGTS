import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  private ShoppingAtivo = "1"
  private MesAnoProcessamento = "04/2021";
  private storage: Storage;
  private urlBase = `${environment.urlBase}/api/util`;

  constructor(private http: HttpClient) {
    this.storage = window.localStorage;
  }

  ngOnInit(): void {
  }

  CarregarMesAnoProcessamento(){
    //let mesano = this.http.get<string>(this.urlBase);
    let mesano = "04/2021";
    this.set("MesAnoProcessamento", mesano);
  }

  CarregarShoppingAtivo() {
    //let mesano = this.http.get<string>(this.urlBase);
    let ShoppingAtivo = "1";
    this.set("ShoppingAtivo", ShoppingAtivo);
  }


  GetMesAnoProcessamento() {
    return this.MesAnoProcessamento;
  }

  GetShoppingAtivo() {
    return this.ShoppingAtivo;
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
