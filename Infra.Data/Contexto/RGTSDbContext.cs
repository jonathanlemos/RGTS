using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Dominio;
using Dominio.Entidades;
using System.Reflection;
using System.Linq;

#nullable disable

namespace Infra.Data
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

        public virtual DbSet<Atividade> Atividade { get; set; }
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<CondominioLuc> CondominioLuc { get; set; }
        public virtual DbSet<ContaCorrente> ContaCorrente { get; set; }
        public virtual DbSet<ContratoFaixasAluguel> ContratoFaixasAluguel { get; set; }
        public virtual DbSet<ContratoLocacao> ContratoLocacao { get; set; }
        public virtual DbSet<ContratoLuc> ContratoLuc { get; set; }
        public virtual DbSet<DescricaoAlternativaRubrica> DescricaoAlternativaRubrica { get; set; }
        public virtual DbSet<EmailsPessoa> EmailsPessoa { get; set; }
        public virtual DbSet<Empreendimento> Empreendimento { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Fase> Fase { get; set; }
        public virtual DbSet<Formula> Formula { get; set; }
        public virtual DbSet<GrupoRubrica> GrupoRubrica { get; set; }
        public virtual DbSet<HistoricoContratoLocacao> HistoricoContratoLocacao { get; set; }
        public virtual DbSet<HistoricoUnidade> HistoricoUnidade { get; set; }
        public virtual DbSet<InstrucaoBoleto> InstrucaoBoleto { get; set; }
        public virtual DbSet<Instrumento> Instrumento { get; set; }
        public virtual DbSet<ItensNd> ItensNd { get; set; }
        public virtual DbSet<ItensNdPartilhado> ItensNdPartilhado { get; set; }
        public virtual DbSet<ItensNdRecebido> ItensNdRecebido { get; set; }
        public virtual DbSet<Localizacao> Localizacao { get; set; }
        public virtual DbSet<Luc> Luc { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<MensagemBoleto> MensagemBoleto { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Nd> Nd { get; set; }
        public virtual DbSet<Nivel> Nivel { get; set; }
        public virtual DbSet<Papel> Papel { get; set; }
        public virtual DbSet<ParametrosShopping> ParametrosShopping { get; set; }
        public virtual DbSet<PartilhaBancarium> PartilhaBancarium { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilPermissao> PerfilPermissao { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaPapelInstrumento> PessoaPapelInstrumento { get; set; }
        public virtual DbSet<PessoaShopping> PessoaShopping { get; set; }
        public virtual DbSet<Ramo> Ramo { get; set; }
        public virtual DbSet<Recebimento> Recebimento { get; set; }
        public virtual DbSet<Rubrica> Rubrica { get; set; }
        public virtual DbSet<SequenciaisAlteracao> SequenciaisAlteracao { get; set; }
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<SerieBeneficiario> SerieBeneficiario { get; set; }
        public virtual DbSet<ServicoCobranca> ServicoCobranca { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<TipoInstrumento> TipoInstrumento { get; set; }
        public virtual DbSet<TipoServicoCobranca> TipoServicoCobranca { get; set; }
        public virtual DbSet<ValoresFaturado> ValoresFaturado { get; set; }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.\\SQLEXPRESS;Database=rgtsdb;User Id=sa; Password=abc123!@#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

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
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome).IsFixedLength(true);

                //entity.HasOne(d => d.Estado)
                //    .WithMany(p => p.Cidades)
                //    .HasForeignKey(d => d.EstadoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Cidade_Estado");
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

                entity.Property(e => e.NumeroContaCorrente).IsUnicode(false);

                entity.Property(e => e.OrdemPartilha).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                //entity.HasOne(d => d.banco)
                //    .WithMany(p => p.ContaCorrentes)
                //    .HasForeignKey(d => d.IdBanco)
                //    .HasConstraintName("FK_ContaCorrente_Banco");
            });

            modelBuilder.Entity<ContratoFaixasAluguel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<ContratoLocacao>(entity =>
            {
                entity.Property(e => e.IdRubricaAluguelPercentual).IsFixedLength(true);

                entity.Property(e => e.Observacao).IsUnicode(false);
            });

            modelBuilder.Entity<DescricaoAlternativaRubrica>(entity =>
            {
                entity.Property(e => e.NomeDescricaAlternativa).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.UsuarioInsercao).IsUnicode(false);

                //entity.HasOne(d => d.rubrica)
                //    .WithMany(p => p.descricaoAlternativaRubrica)
                //    .HasForeignKey(d => d.IdRubrica)
                //    .HasConstraintName("FK_DescricaoAlternativaRubrica_Rubrica");
            });

            modelBuilder.Entity<EmailsPessoa>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                //entity.HasOne(d => d.pessoa)
                //    .WithMany(p => p.EmailsPessoas)
                //    .HasForeignKey(d => d.IdPessoa)
                //    .HasConstraintName("FK_Emails_Pessoa");
            });

            modelBuilder.Entity<Empreendimento>(entity =>
            {
                entity.Property(e => e.NomeEmpreendimento).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.UsuarioInsercao).IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome).IsFixedLength(true);

                entity.Property(e => e.Sigla).IsUnicode(false);
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

            modelBuilder.Entity<InstrucaoBoleto>(entity =>
            {
                entity.Property(e => e.Instrucao1).IsUnicode(false);

                entity.Property(e => e.Instrucao2).IsUnicode(false);

                entity.Property(e => e.Instrucao3).IsUnicode(false);

                entity.Property(e => e.Instrucao4).IsUnicode(false);

                entity.Property(e => e.Instrucao5).IsUnicode(false);

                entity.Property(e => e.Instrucao6).IsUnicode(false);

                entity.Property(e => e.NomeInstrucao).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
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

                //entity.HasOne(d => d.nd)
                //    .WithMany(p => p.ItensNds)
                //    .HasForeignKey(d => d.IdNd)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ItensND_ND");

                //entity.HasOne(d => d.rubrica)
                //    .WithMany(p => p.ItensNds)
                //    .HasForeignKey(d => d.IdRubrica)
                //    .HasConstraintName("FK_ItensNd_Rubrica");
            });

            modelBuilder.Entity<ItensNdPartilhado>(entity =>
            {
                //entity.HasOne(d => d.partilhaBancarium)
                //    .WithMany(p => p.itensNdPartilhado)
                //    .HasForeignKey(d => d.IdPartilhaBancaria)
                //    .HasConstraintName("FK_ItensNdPartilhado_PartilhaBancarium");
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

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.NomeMarca).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);
            });

            modelBuilder.Entity<MensagemBoleto>(entity =>
            {
                entity.Property(e => e.Mensagem1).IsUnicode(false);

                entity.Property(e => e.Mensagem2).IsUnicode(false);

                entity.Property(e => e.Mensagem3).IsUnicode(false);

                entity.Property(e => e.Mensagem4).IsUnicode(false);

                entity.Property(e => e.Mensagem5).IsUnicode(false);

                entity.Property(e => e.Mensagem6).IsUnicode(false);

                entity.Property(e => e.NomeMensagem).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NomeMunicipio).IsUnicode(false);

                //entity.HasOne(d => d.IdEstadoNavigation)
                //    .WithMany(p => p.Municipios)
                //    .HasForeignKey(d => d.IdEstado)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Municipio_Estado");
            });

            modelBuilder.Entity<Nd>(entity =>
            {
                entity.Property(e => e.ArquivoRemessa).IsUnicode(false);

                entity.Property(e => e.ArquivoRetorno).IsUnicode(false);

                entity.Property(e => e.DigitoNossoNumero).IsUnicode(false);

                entity.Property(e => e.NossoNumero).IsUnicode(false);

                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                //entity.HasOne(d => d.servicoCobranca)
                //    .WithMany(p => p.nds)
                //    .HasForeignKey(d => d.IdServicoCobranca)
                //    .HasConstraintName("FK_Nd_ServicoCobranca");

                //entity.HasOne(d => d.beneficiario)
                //    .WithMany(p => p.ndsBeneficiario)
                //    .HasForeignKey(d => d.PessoaBeneficiario)
                //    .HasConstraintName("FK_Nd_Pessoa_Beneficiario");

                //entity.HasOne(d => d.pagador)
                //    .WithMany(p => p.ndsPagador)
                //    .HasForeignKey(d => d.PessoaPagador)
                //    .HasConstraintName("FK_Nd_Pessoa_Pagador");
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

            modelBuilder.Entity<PartilhaBancarium>(entity =>
            {
                entity.Property(e => e.Usuario).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                //entity.HasOne(d => d.contaCorrente)
                //    .WithMany(p => p.PartilhaBancaria)
                //    .HasForeignKey(d => d.IdContaCorrente)
                //    .HasConstraintName("FK_PartilhaBancaria_ContaCorrente");

                //entity.HasOne(d => d.servicoCobranca)
                //    .WithMany(p => p.partilhaBancarium)
                //    .HasForeignKey(d => d.IdServicoCobranca)
                //    .HasConstraintName("FK_PartilhaBancaria_ServicoCobranca");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao).IsFixedLength(true);
            });

            modelBuilder.Entity<PerfilPermissao>(entity =>
            {
                entity.Property(e => e.Id).IsFixedLength(true);

                //entity.HasOne(d => d.Perfil)
                //    .WithMany(p => p.PerfilPermissaos)
                //    .HasForeignKey(d => d.PerfilId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_PerfilPermissao_Perfil");

                //entity.HasOne(d => d.Permissao)
                //    .WithMany(p => p.PerfilPermissaos)
                //    .HasForeignKey(d => d.PermissaoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_PerfilPermissao_Permissao");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao).IsFixedLength(true);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Bairro).IsUnicode(false);

                entity.Property(e => e.Celular1).IsUnicode(false);

                entity.Property(e => e.Celular2).IsUnicode(false);

                entity.Property(e => e.Celular3).IsUnicode(false);

                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Complemento).IsUnicode(false);

                entity.Property(e => e.CpfCnpj).IsFixedLength(true);

                entity.Property(e => e.Email).IsFixedLength(true);

                entity.Property(e => e.InscricaoEstadual).IsFixedLength(true);

                entity.Property(e => e.InscricaoMunicipal).IsFixedLength(true);

                entity.Property(e => e.Logradouro).IsUnicode(false);

                entity.Property(e => e.Nacionalidade).IsFixedLength(true);

                entity.Property(e => e.Nome).IsFixedLength(true);

                entity.Property(e => e.Numero).IsUnicode(false);

                entity.Property(e => e.OrgaoEmissor).IsFixedLength(true);

                entity.Property(e => e.PrimeiroNome).IsFixedLength(true);

                entity.Property(e => e.RazaoSocial).IsFixedLength(true);

                entity.Property(e => e.Rg).IsFixedLength(true);

                entity.Property(e => e.Senha).IsFixedLength(true);

                entity.Property(e => e.Telefone1).IsUnicode(false);

                entity.Property(e => e.Telefone2).IsUnicode(false);

                entity.Property(e => e.Telefone3).IsUnicode(false);

                //entity.HasOne(d => d.Cidade)
                //    .WithMany(p => p.Pessoas)
                //    .HasForeignKey(d => d.CidadeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Pessoa_Cidade");

                //entity.HasOne(d => d.tipoPessoa)
                //    .WithMany(p => p.Pessoas)
                //    .HasForeignKey(d => d.TipoPessoa)
                //    .HasConstraintName("FK_Pessoa_Sexo");

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

                entity.Property(e => e.Empresa).IsUnicode(false);

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

                //entity.HasOne(d => d.contaCorrente)
                //    .WithMany(p => p.servicoCobranca)
                //    .HasForeignKey(d => d.IdContaCorrente)
                //    .HasConstraintName("FK_ServicoCobranca_ContaCorrente");

                //entity.HasOne(d => d.tipoServicoCobranca)
                //    .WithMany(p => p.servicoCobranca)
                //    .HasForeignKey(d => d.IdTipoServicoCobranca)
                //    .HasConstraintName("FK_ServicoCobranca_TipoServicoCobranca");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao).IsFixedLength(true);
            });

            modelBuilder.Entity<TipoInstrumento>(entity =>
            {
                entity.Property(e => e.NomeInstrumento).IsUnicode(false);
            });

            modelBuilder.Entity<TipoServicoCobranca>(entity =>
            {
                entity.Property(e => e.NomeTipoServicoCobranca).IsUnicode(false);
            });

            modelBuilder.Entity<ValoresFaturado>(entity =>
            {
                entity.Property(e => e.Documento).IsUnicode(false);

                entity.Property(e => e.UsuarioAlteracao).IsUnicode(false);

                entity.Property(e => e.UsuarioInsercao).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.GetType().GetProperty("DataCadastro") != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCadastro").IsModified = false;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
