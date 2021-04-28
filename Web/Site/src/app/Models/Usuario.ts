export class Usuario {
  id: number;
  email: string;
  senha: string;
  primeiroNome: string;
  nomeCompleto: string;
  endereco: string;
  complemento: string;
  numero: number;
  cidadeId: number;
  estadoId: number;
  cep: string;
  sexoId: number;
  dataCadastro: Date;
  ativo: Boolean;
  tipoPessoa: string;
}

export class LoginUsuario {
  email: string;
  senha: string;
  primeiroNome: string;
  nomeCompleto: string;
}
