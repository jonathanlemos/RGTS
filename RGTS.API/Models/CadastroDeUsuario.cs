using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RGTS.API.Models
{
    public class CadastroDeUsuario
    {
        public string Cep { get; set; }
        public Cidade Cidade { get; set; }
        public string Complemento { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public Estado Estado { get; set; }
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public int Numero { get; set; }
        public string PrimeiroNome { get; set; }
        public string Senha { get; set; }
        public Sexo Sexo { get; set; }

    }
}
