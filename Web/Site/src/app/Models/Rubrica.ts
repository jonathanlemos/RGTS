import { Serie } from './Serie'
import { GrupoRubrica } from './grupoRubrica';

export class Rubrica {
  id: number;
  nomeRubrica: string;
  idSerie: number;
  grupoRubrica: GrupoRubrica;
}
