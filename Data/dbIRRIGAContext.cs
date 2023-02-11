using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IRRIGA.Data
{
    public partial class dbIRRIGAContext : IdentityDbContext
    {
        public dbIRRIGAContext()
        {
        }

        public dbIRRIGAContext(DbContextOptions<dbIRRIGAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Associacao> Associacaos { get; set; }
        public virtual DbSet<AssociacaoRegadio> AssociacaoRegadios { get; set; }
        public virtual DbSet<Beneficiario> Beneficiarios { get; set; }
        public virtual DbSet<BeneficiarioEscola> BeneficiarioEscolas { get; set; }
        public virtual DbSet<Componente> Componentes { get; set; }
        public virtual DbSet<Cultura> Culturas { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<EscolaMachamba> EscolaMachambas { get; set; }
        public virtual DbSet<EscolaRegadio> EscolaRegadios { get; set; }
        public virtual DbSet<Fieldset> Fieldsets { get; set; }
        public virtual DbSet<Inquerito> Inqueritos { get; set; }
        public virtual DbSet<InqueritoPerguntum> InqueritoPergunta { get; set; }
        public virtual DbSet<InqueritoRespostum> InqueritoResposta { get; set; }
        public virtual DbSet<LogApp> LogApps { get; set; }
        public virtual DbSet<MobileSync> MobileSyncs { get; set; }
        public virtual DbSet<PerguntaOpcao> PerguntaOpcaos { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Regadio> Regadios { get; set; }
        public virtual DbSet<ResponsesInquerito> ResponsesInqueritos { get; set; }
        public virtual DbSet<SubInquerito> SubInqueritos { get; set; }
        public virtual DbSet<TipoCultura> TipoCulturas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioAssociaco> UsuarioAssociacoes { get; set; }
        public virtual DbSet<UsuarioEscola> UsuarioEscolas { get; set; }
        public virtual DbSet<UsuarioInquerito> UsuarioInqueritos { get; set; }
        public virtual DbSet<UsuarioRegadio> UsuarioRegadios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Associacao>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Designacao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<AssociacaoRegadio>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdAssociacaoNavigation)
                    .WithMany(p => p.AssociacaoRegadios)
                    .HasForeignKey(d => d.IdAssociacao)
                    .HasConstraintName("FK_AssociacaoRegadio_Associacao");

                entity.HasOne(d => d.IdRegadioNavigation)
                    .WithMany(p => p.AssociacaoRegadios)
                    .HasForeignKey(d => d.IdRegadio)
                    .HasConstraintName("FK_AssociacaoRegadio_Regadio");
            });

            modelBuilder.Entity<Beneficiario>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Apelido).IsUnicode(false);

                entity.Property(e => e.CodeBenificiario).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Genero).IsUnicode(false);

                entity.Property(e => e.Localidade).IsUnicode(false);

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.NumDodcIdenticacao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);

                entity.Property(e => e.TipoDocIdentificacao).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdAssociacaoNavigation)
                    .WithMany(p => p.Beneficiarios)
                    .HasForeignKey(d => d.IdAssociacao)
                    .HasConstraintName("FK_Beneficiario_Associacao");

                entity.HasOne(d => d.IdRegadioNavigation)
                    .WithMany(p => p.Beneficiarios)
                    .HasForeignKey(d => d.IdRegadio)
                    .HasConstraintName("FK_Beneficiario_Regadio");
            });

            modelBuilder.Entity<BeneficiarioEscola>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdBeneficiarioNavigation)
                    .WithMany(p => p.BeneficiarioEscolas)
                    .HasForeignKey(d => d.IdBeneficiario)
                    .HasConstraintName("FK_BeneficiarioEscolas_Beneficiario");

                entity.HasOne(d => d.IdEscolaNavigation)
                    .WithMany(p => p.BeneficiarioEscolas)
                    .HasForeignKey(d => d.IdEscola)
                    .HasConstraintName("FK_BeneficiarioEscolas_EscolaMachamba");
            });

            modelBuilder.Entity<Componente>(entity =>
            {
                entity.Property(e => e.Caracteristicas).IsUnicode(false);

                entity.Property(e => e.Designacao).IsUnicode(false);

                entity.Property(e => e.Validacao).IsUnicode(false);
            });

            modelBuilder.Entity<Cultura>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Designacao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdTipoCulturaNavigation)
                    .WithMany(p => p.Culturas)
                    .HasForeignKey(d => d.IdTipoCultura)
                    .HasConstraintName("FK_Cultura_TipoCultura");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_Districts_Provinces");
            });

            modelBuilder.Entity<EscolaMachamba>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Designacao).IsUnicode(false);

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.Metodologia).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<EscolaRegadio>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdEscolaNavigation)
                    .WithMany(p => p.EscolaRegadios)
                    .HasForeignKey(d => d.IdEscola)
                    .HasConstraintName("FK_EscolaRegadios_EscolaMachamba");

                entity.HasOne(d => d.IdRegadioNavigation)
                    .WithMany(p => p.EscolaRegadios)
                    .HasForeignKey(d => d.IdRegadio)
                    .HasConstraintName("FK_EscolaRegadios_Regadio");
            });

            modelBuilder.Entity<Fieldset>(entity =>
            {
                entity.Property(e => e.CaracteristicasComponente).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Label).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdInqueritoNavigation)
                    .WithMany(p => p.Fieldsets)
                    .HasForeignKey(d => d.IdInquerito)
                    .HasConstraintName("FK_Fieldsets_Inquerito");
            });

            modelBuilder.Entity<Inquerito>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Designacao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdRegadioNavigation)
                    .WithMany(p => p.Inqueritos)
                    .HasForeignKey(d => d.IdRegadio)
                    .HasConstraintName("FK_Inquerito_Regadio");
            });

            modelBuilder.Entity<InqueritoPerguntum>(entity =>
            {
                entity.Property(e => e.CaracteristicasComponente).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.Property(e => e.ValidacaoComponente).IsUnicode(false);

                entity.HasOne(d => d.IdComponenteNavigation)
                    .WithMany(p => p.InqueritoPergunta)
                    .HasForeignKey(d => d.IdComponente)
                    .HasConstraintName("FK_InqueritoPergunta_Componente");

                entity.HasOne(d => d.IdFieldsetNavigation)
                    .WithMany(p => p.InqueritoPergunta)
                    .HasForeignKey(d => d.IdFieldset)
                    .HasConstraintName("FK_InqueritoPergunta_Fieldsets");

                entity.HasOne(d => d.IdInqueritoNavigation)
                    .WithMany(p => p.InqueritoPergunta)
                    .HasForeignKey(d => d.IdInquerito)
                    .HasConstraintName("FK_InqueritoPergunta_Inquerito");
            });

            modelBuilder.Entity<InqueritoRespostum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApprovedBy).IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdFieldsetsNavigation)
                    .WithMany(p => p.InqueritoResposta)
                    .HasForeignKey(d => d.IdFieldsets)
                    .HasConstraintName("FK_InqueritoResposta_Fieldsets");

                entity.HasOne(d => d.IdInqueritoNavigation)
                    .WithMany(p => p.InqueritoResposta)
                    .HasForeignKey(d => d.IdInquerito)
                    .HasConstraintName("FK_InqueritoResposta_Inquerito");

                entity.HasOne(d => d.IdPerguntaNavigation)
                    .WithMany(p => p.InqueritoResposta)
                    .HasForeignKey(d => d.IdPergunta)
                    .HasConstraintName("FK_InqueritoResposta_InqueritoPergunta");

                entity.HasOne(d => d.IdResponsesNavigation)
                    .WithMany(p => p.InqueritoResposta)
                    .HasForeignKey(d => d.IdResponses)
                    .HasConstraintName("FK_InqueritoResposta_Responses");
            });

            modelBuilder.Entity<LogApp>(entity =>
            {
                entity.Property(e => e.Acao).IsUnicode(false);

                entity.Property(e => e.IdUser).IsUnicode(false);

                entity.Property(e => e.Local).IsUnicode(false);
            });

            modelBuilder.Entity<MobileSync>(entity =>
            {
                entity.Property(e => e.DeviceImei).IsUnicode(false);

                entity.Property(e => e.SyncedBy).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<PerguntaOpcao>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdPerguntaNavigation)
                    .WithMany(p => p.PerguntaOpcaos)
                    .HasForeignKey(d => d.IdPergunta)
                    .HasConstraintName("FK_PerguntaOpcao_InqueritoPergunta");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Regadio>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CodeRegadio).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Designacao).IsUnicode(false);

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<ResponsesInquerito>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApprovedBy).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdBeneficiarioNavigation)
                    .WithMany(p => p.ResponsesInqueritos)
                    .HasForeignKey(d => d.IdBeneficiario)
                    .HasConstraintName("FK_ResponsesInquerito_Beneficiario");

                entity.HasOne(d => d.IdEscolaNavigation)
                    .WithMany(p => p.ResponsesInqueritos)
                    .HasForeignKey(d => d.IdEscola)
                    .HasConstraintName("FK_ResponsesInquerito_EscolaMachamba");

                entity.HasOne(d => d.IdInqueritoNavigation)
                    .WithMany(p => p.ResponsesInqueritos)
                    .HasForeignKey(d => d.IdInquerito)
                    .HasConstraintName("FK_Responses_Inquerito");

                entity.HasOne(d => d.IdRegadioNavigation)
                    .WithMany(p => p.ResponsesInqueritos)
                    .HasForeignKey(d => d.IdRegadio)
                    .HasConstraintName("FK_ResponsesInquerito_Regadio");
            });

            modelBuilder.Entity<SubInquerito>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdInqueritoNavigation)
                    .WithMany(p => p.SubInqueritoIdInqueritoNavigations)
                    .HasForeignKey(d => d.IdInquerito)
                    .HasConstraintName("FK_SubInquerito_Inquerito");

                entity.HasOne(d => d.IdSubInqueritoNavigation)
                    .WithMany(p => p.SubInqueritoIdSubInqueritoNavigations)
                    .HasForeignKey(d => d.IdSubInquerito)
                    .HasConstraintName("FK_SubInquerito_Inquerito1");
            });

            modelBuilder.Entity<TipoCultura>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Designacao).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdAssociacaoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdAssociacao)
                    .HasConstraintName("FK_Usuarios_Associacao");

                entity.HasOne(d => d.IdRegadioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRegadio)
                    .HasConstraintName("FK_Usuarios_Regadio");
            });

            modelBuilder.Entity<UsuarioAssociaco>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdAssociacaoNavigation)
                    .WithMany(p => p.UsuarioAssociacos)
                    .HasForeignKey(d => d.IdAssociacao)
                    .HasConstraintName("FK_UsuarioAssociacoes_Associacao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioAssociacos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_UsuarioAssociacoes_Usuarios");
            });

            modelBuilder.Entity<UsuarioEscola>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdEscolaNavigation)
                    .WithMany(p => p.UsuarioEscolas)
                    .HasForeignKey(d => d.IdEscola)
                    .HasConstraintName("FK_UsuarioEscolas_EscolaMachamba");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioEscolas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_UsuarioEscolas_Usuarios");
            });

            modelBuilder.Entity<UsuarioInquerito>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdInqueritoNavigation)
                    .WithMany(p => p.UsuarioInqueritos)
                    .HasForeignKey(d => d.IdInquerito)
                    .HasConstraintName("FK_UsuarioInqueritos_Inquerito");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioInqueritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_UsuarioInqueritos_Usuarios");
            });

            modelBuilder.Entity<UsuarioRegadio>(entity =>
            {
                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.RemovedBy).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.IdRegadioNavigation)
                    .WithMany(p => p.UsuarioRegadios)
                    .HasForeignKey(d => d.IdRegadio)
                    .HasConstraintName("FK_UsuarioRegadios_Regadio");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioRegadios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_UsuarioRegadios_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
