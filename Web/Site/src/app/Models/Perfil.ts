import { Permissao } from "./Permissao";

export class Perfil {
    id: number | undefined;
    nome: string | undefined;
    descricao: string | undefined;
    listaPermissao: Permissao[] | undefined;
  }
