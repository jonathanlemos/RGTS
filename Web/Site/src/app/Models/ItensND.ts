import { Rubrica } from './rubrica';

export class ItensND {
  id: number;
  valorPrincipalRubrica: number;
  valorCorrecaoRubrica: number;
  valorMultaRubrica: number;
  valorJurosRubrica: number;
  anoCompetencia: number;
  mesCompetencia: number;
  nome: string;
  rubrica: Rubrica;
}
