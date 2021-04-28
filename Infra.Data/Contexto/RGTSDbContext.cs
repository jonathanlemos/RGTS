using System;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infra.Data.Contexto
{
    public partial class RGTSDbContext : DbContext
    {
        public RGTSDbContext()
        {
        }

        public RGTSDbContext(DbContextOptions<RGTSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<Banco> Bancos { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Condominio> Condominios { get; set; }
        public virtual DbSet<CondominioLuc> CondominioLucs { get; set; }
        public virtual DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public virtual DbSet<ContratoFaixasAluguel> ContratoFaixasAluguels { get; set; }
        public virtual DbSet<ContratoLocacao> ContratoLocacaos { get; set; }
        public virtual DbSet<ContratoLuc> ContratoLucs { get; set; }
        public virtual DbSet<DescricaoAlternativaRubrica> DescricaoAlternativaRubricas { get; set; }
        public virtual DbSet<EmailsPessoa> EmailsPessoas { get; set; }
        public virtual DbSet<Empreendimento> Empreendimentos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Fase> Fases { get; set; }
        public virtual DbSet<Formula> Formulas { get; set; }
        public virtual DbSet<GrupoRubrica> GrupoRubricas { get; set; }
        public virtual DbSet<HistoricoContratoLocacao> HistoricoContratoLocacaos { get; set; }
        public virtual DbSet<HistoricoUnidade> HistoricoUnidades { get; set; }
        public virtual DbSet<Instrumento> Instrumentos { get; set; }
        public virtual DbSet<ItensNd> ItensNds { get; set; }
        public virtual DbSet<Localizacao> Localizacaos { get; set; }
        public virtual DbSet<Luc> Lucs { get; set; }
        public virtual DbSet<LoginPessoa> Logins { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Nd> Nds { get; set; }
        public virtual DbSet<Nivel> Nivels { get; set; }
        public virtual DbSet<Papel> Papels { get; set; }
        public virtual DbSet<ParametrosShopping> ParametrosShoppings { get; set; }
        public virtual DbSet<PartilhaRubricaContaCorrente> PartilhaRubricaContaCorrentes { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<PerfilPermissao> PerfilPermissaos { get; set; }
        public virtual DbSet<Permissao> Permissaos { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<PessoaPapelInstrumento> PessoaPapelInstrumentos { get; set; }
        public virtual DbSet<PessoaShopping> PessoaShoppings { get; set; }
        public virtual DbSet<Ramo> Ramos { get; set; }
        public virtual DbSet<Recebimento> Recebimentos { get; set; }
        public virtual DbSet<Rubrica> Rubricas { get; set; }
        public virtual DbSet<RubricasRecebida> RubricasRecebidas { get; set; }
        public virtual DbSet<SequenciaislAlteracao> SequenciaislAlteracaos { get; set; }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<SerieBeneficiario> SerieBeneficiarios { get; set; }
        public virtual DbSet<ServicoCobranca> ServicoCobrancas { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<TipoInstrumento> TipoInstrumentos { get; set; }
        public virtual DbSet<ValoresFaturado> ValoresFaturados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=rgts-dev.ch0sy8hf0okh.us-east-2.rds.amazonaws.com,1433;Database=rgtdb_dev; User Id=admin; Password=h96GJYM3;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Atividade>(entity =>
            {
                entity.Property(e => e.NomeAtividade).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.Property(e => e.DvBanco).IsUnicode(false);

                entity.Property(e => e.NomeBanco).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.Property(e => e.Nome).IsFixedLength(true);
            });

            modelBuilder.Entity<Condominio>(entity =>
            {
                entity.Property(e => e.NomeCondominio).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<CondominioLuc>(entity =>
            {
                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<ContaCorrente>(entity =>
            {
                entity.Property(e => e.Agencia).IsUnicode(false);

                entity.Property(e => e.DvAgencia).IsUnicode(false);

                entity.Property(e => e.DvContaCorrente).IsUnicode(false);

                entity.Property(e => e.OrdemPartilha).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
            });

            modelBuilder.Entity<ContratoFaixasAluguel>(entity =>
            {
                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<ContratoLocacao>(entity =>
            {
                entity.Property(e => e.IdItemRubricaAluguelPercentual).IsFixedLength(true);

                entity.Property(e => e.Observacao).IsUnicode(false);
            });

            modelBuilder.Entity<DescricaoAlternativaRubrica>(entity =>
            {
                entity.Property(e => e.NomeDescricaAlternativa).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.UsuarioInsercao).IsUnicode(false);
            });

            modelBuilder.Entity<EmailsPessoa>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);
            });

            modelBuilder.Entity<Empreendimento>(entity =>
            {
                entity.Property(e => e.NomeEmpreendimento).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.UsuarioInsercao).IsUnicode(false);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Bairro).IsFixedLength(true);

                entity.Property(e => e.Cep).IsFixedLength(true);

                entity.Property(e => e.Complemento).IsFixedLength(true);

                entity.Property(e => e.Descricao).IsFixedLength(true);

                entity.Property(e => e.Pais).IsFixedLength(true);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Nome).IsFixedLength(true);

                entity.Property(e => e.Sigla).IsFixedLength(true);
            });

            modelBuilder.Entity<Fase>(entity =>
            {
                entity.Property(e => e.NomeFase).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<Formula>(entity =>
            {
                entity.Property(e => e.Expressao).IsUnicode(false);

                entity.Property(e => e.NomeFormula).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<GrupoRubrica>(entity =>
            {
                entity.Property(e => e.NomeGrupoRubrica).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<Instrumento>(entity =>
            {
                entity.Property(e => e.IdInstrumentoContrato).IsFixedLength(true);

                entity.Property(e => e.IdTipoInstrumentoOrigem).IsFixedLength(true);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<ItensNd>(entity =>
            {
                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.Property(e => e.NomeLocalizacao).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<Luc>(entity =>
            {
                entity.Property(e => e.NomeLuc).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<LoginPessoa>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.LoginAcesso).IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NomeMarca).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<Nd>(entity =>
            {
                entity.Property(e => e.ArquivoRemessa).IsUnicode(false);

                entity.Property(e => e.ArquivoRetorno).IsUnicode(false);

                entity.Property(e => e.DigitoNossoNumero).IsUnicode(false);

                entity.Property(e => e.NossoNumero).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.Property(e => e.NomeNivel).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<Papel>(entity =>
            {
                entity.Property(e => e.NomePapel).IsUnicode(false);
            });

            modelBuilder.Entity<ParametrosShopping>(entity =>
            {
                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.LogoAdm).IsUnicode(false);

                entity.Property(e => e.NomeShopping).IsUnicode(false);

                entity.Property(e => e.Numero).IsUnicode(false);

                entity.Property(e => e.SiglaEstado).IsUnicode(false);

                entity.Property(e => e.SiglaShopping).IsUnicode(false);

                entity.Property(e => e.UsuarioAltecao).IsUnicode(false);

                entity.Property(e => e.UsuarioInsercao).IsUnicode(false);
            });

            modelBuilder.Entity<PartilhaRubricaContaCorrente>(entity =>
            {
                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.Property(e => e.Descricao).IsFixedLength(true);
            });

            modelBuilder.Entity<PerfilPermissao>(entity =>
            {
                entity.Property(e => e.Id).IsFixedLength(true);
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.Property(e => e.Descricao).IsFixedLength(true);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.Bairro).IsUnicode(false);

                entity.Property(e => e.Celular1).IsUnicode(false);

                entity.Property(e => e.Celular2).IsUnicode(false);

                entity.Property(e => e.Celular3).IsUnicode(false);

                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Complemento).IsUnicode(false);

                entity.Property(e => e.CpfCnpj).IsFixedLength(true);

                entity.Property(e => e.Email).IsFixedLength(true);

                entity.Property(e => e.EstadoCivil).IsFixedLength(true);

                entity.Property(e => e.InscricaoEstadual).IsFixedLength(true);

                entity.Property(e => e.InscricaoMunicipal).IsFixedLength(true);

                entity.Property(e => e.Logradouro).IsUnicode(false);

                entity.Property(e => e.Marca).IsFixedLength(true);

                entity.Property(e => e.Nacionalidade).IsFixedLength(true);

                entity.Property(e => e.Nome).IsFixedLength(true);

                entity.Property(e => e.Numero).IsUnicode(false);

                entity.Property(e => e.OrgaoEmissor).IsFixedLength(true);

                entity.Property(e => e.PrimeiroNome).IsFixedLength(true);

                entity.Property(e => e.RazaoSocial).IsFixedLength(true);

                entity.Property(e => e.RegimeCasamento).IsFixedLength(true);

                entity.Property(e => e.Rg).IsFixedLength(true);

                entity.Property(e => e.Senha).IsFixedLength(true);

                entity.Property(e => e.Telefone1).IsUnicode(false);

                entity.Property(e => e.Telefone2).IsUnicode(false);

                entity.Property(e => e.Telefone3).IsUnicode(false);
            });

            modelBuilder.Entity<PessoaShopping>(entity =>
            {
                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<Ramo>(entity =>
            {
                entity.Property(e => e.NomeRamo).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<Recebimento>(entity =>
            {
                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
            });

            modelBuilder.Entity<Rubrica>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NomeRubrica).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.UsuarioInsercao).IsUnicode(false);
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.Property(e => e.NomeSerie).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<SerieBeneficiario>(entity =>
            {
                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<ServicoCobranca>(entity =>
            {
                entity.Property(e => e.Carteira).IsUnicode(false);

                entity.Property(e => e.Convenio).IsUnicode(false);

                entity.Property(e => e.ExtensaoArquivoRemessa).IsUnicode(false);

                entity.Property(e => e.ExtensaoArquivoRetorno).IsUnicode(false);

                entity.Property(e => e.NomeServico).IsUnicode(false);

                entity.Property(e => e.PrefixoArquivoRemessa).IsUnicode(false);

                entity.Property(e => e.PrefixoArquivoRetorno).IsUnicode(false);

                entity.Property(e => e.SequencialArquivoRemessa).IsUnicode(false);

                entity.Property(e => e.SequencialArquivoRetorno).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.Variacao).IsUnicode(false);
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.Property(e => e.Descricao).IsFixedLength(true);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Telefone1).IsFixedLength(true);

                entity.Property(e => e.Telefone2).IsFixedLength(true);

                entity.Property(e => e.Telefone3).IsFixedLength(true);

                entity.Property(e => e.TelefonePrincipal).IsFixedLength(true);
            });

            modelBuilder.Entity<TipoInstrumento>(entity =>
            {
                entity.Property(e => e.NomeInstrumento).IsUnicode(false);
            });

            modelBuilder.Entity<ValoresFaturado>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Documento).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.UsuarioInsercao).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
