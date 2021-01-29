import { Perfil } from "./Perfil";

export class Permissao {
    id: number | undefined;
    nome: string | undefined;
    descricao: string | undefined;
    perfil: Perfil | undefined;
    listaPerfil: Perfil[] | undefined;
  } 
