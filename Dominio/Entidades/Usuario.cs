using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(int id,
                        string email,
                        string senha,
                        string primeiroNome,
                        string nomeCompleto,
                        string endereco,
                        string complemento,
                        int numero,
                        int cidadeId,
                        int estadoId,
                        string cep,
                        int sexoId)
        {
            this.Id = id;
            this.Email = email;
            this.Senha = senha;
            this.PrimeiroNome = primeiroNome;
            this.NomeCompleto = nomeCompleto;
            this.Endereco = endereco;
            this.Complemento = complemento;
            this.Numero = numero;
            this.CidadeId = cidadeId;
            this.EstadoId = estadoId;
            this.Cep = cep;
            this.SexoId = sexoId;
        }

        [Column("UsuarioId", TypeName = "int")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("Email", TypeName = "nvarchar")]
        [MaxLength(50, ErrorMessage = "Máximo permitido de 50 caracteres.")]
        [MinLength(8, ErrorMessage = "Verifique o E-mail digitado.")]
        [Required(ErrorMessage = "E-mail obrigatório")]
        public string Email { get; set; }

        [Column("Senha", TypeName = "nvarchar")]
        [MaxLength(10, ErrorMessage = "Máximo permitido de 10 caracteres.")]
        [MinLength(5, ErrorMessage = "Mínimo permitido de 5 caracteres.")]
        [Required]
        public string Senha { get; set; }

        [Column("PrimeiroNome", TypeName = "nvarchar")]
        [MaxLength(10, ErrorMessage = "Máximo permitido de 10 caracteres.")]
        [MinLength(5, ErrorMessage = "Mínimo permitido de 5 caracteres.")]
        [Required]
        public string PrimeiroNome { get; set; }

        [Column("NomeCompleto", TypeName = "nvarchar")]
        [MaxLength(100, ErrorMessage = "Máximo permitido de 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Mínimo permitido de 5 caracteres.")]
        [Required]
        public string NomeCompleto { get; set; }

        [Column("Endereco", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Endereco { get; set; }

        [Column("Complemento", TypeName = "nvarchar")]
        [MaxLength(10)]
        public string Complemento { get; set; }

        [Column("Numero", TypeName = "int")]
        public int Numero { get; set; }

        [Column("CidadeId", TypeName = "int")]
        [ForeignKey("Cidade")]
        [Required]
        public int CidadeId { get; set; }

        [Column("EstadoId", TypeName = "int")]
        [ForeignKey("Estado")]
        [Required]
        public int EstadoId { get; set; }

        [Column("Cep", TypeName = "nvarchar")]
        [MaxLength(20)]
        public string Cep { get; set; }

        [Column("SexoId", TypeName = "int")]
        [ForeignKey("Sexo")]
        [Required]
        public int SexoId { get; set; }

        [Column("DtCadastro", TypeName = "datetime")]
        [Required]
        public DateTime DataCadastro { get; set; }

        [Column("Ativo", TypeName = "bit")]
        [Required]
        public Boolean Ativo { get; set; }

        //[ForeignKey("Perfil")]
        //public List<Perfil> ListaPerfil { get; set; }

        //[ForeignKey("Perfil")]
        public Perfil Perfil { get; set; }

        //[ForeignKey("Permissao")]
        //public List<Permissao> ListaPermissao { get; set; }

        //[ForeignKey("Permissao")]
        public Permissao Permissao { get; set; }
    }
}
