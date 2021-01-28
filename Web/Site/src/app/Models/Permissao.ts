import { Perfil } from "./Perfil";

export class Permissao {
    Id: number | undefined;
    Nome: string | undefined;
    Descricao: string | undefined;
    Perfil: Perfil | undefined;
    ListaPerfil: Perfil[] | undefined;
  } 
