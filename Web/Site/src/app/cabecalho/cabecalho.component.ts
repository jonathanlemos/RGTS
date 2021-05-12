import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../Servicos/LocalStorage/local-storage.service';
 
@Component({
  selector: 'app-cabecalho',
  templateUrl: './cabecalho.component.html',
  styleUrls: ['./cabecalho.component.css']
})
export class CabecalhoComponent implements OnInit {

  public MesAnoProcessamento: string;

  constructor(private localStorageService: LocalStorageService)
  {

  }

  ngOnInit(): void {
    this.localStorageService.CarregarMesAnoProcessamento();
    this.MesAnoProcessamento = this.localStorageService.get("MesAnoProcessamento");
  }

}
