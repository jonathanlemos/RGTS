import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../Servicos/LocalStorage/local-storage.service';
 
@Component({
  selector: 'app-cabecalho',
  templateUrl: './cabecalho.component.html',
  styleUrls: ['./cabecalho.component.css']
})
export class CabecalhoComponent implements OnInit {

  public MesAnoReferencia: string;

  constructor(private localStorageService: LocalStorageService)
  {

  }

  ngOnInit(): void {
    this.localStorageService.CarregarMesAnoReferencia();
    this.MesAnoReferencia = this.localStorageService.get("MesAnoReferencia");
  }

}
