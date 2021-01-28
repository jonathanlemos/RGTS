import { Permissao } from "./Permissao";

export class Perfil {
    Id: number | undefined;
    Nome: string | undefined;
    Descricao: string | undefined;
    ListaPermissao: Permissao[] | undefined;
  }
