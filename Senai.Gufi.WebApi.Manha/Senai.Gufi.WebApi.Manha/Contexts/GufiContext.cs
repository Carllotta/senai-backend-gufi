using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Gufi.WebApi.Manha.Domains
{
    public partial class GufiContext : DbContext
    {
        public GufiContext()
        {
        }

        public GufiContext(DbContextOptions<GufiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Instituicao> Instituicao { get; set; }
        public virtual DbSet<Presenca> Presenca { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NOTE1202362\\SQLEXPRESS; Initial Catalog=Gufi_Manha; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.Property(e => e.IdEvento).HasColumnName("ID_Evento");

                entity.Property(e => e.AcessoLivre)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkInstituicao).HasColumnName("FK_Instituicao");

                entity.Property(e => e.FkTipoEvento).HasColumnName("FK_TipoEvento");

                entity.Property(e => e.NomeEvento)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkInstituicaoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.FkInstituicao)
                    .HasConstraintName("FK__Evento__FK_Insti__59063A47");

                entity.HasOne(d => d.FkTipoEventoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.FkTipoEvento)
                    .HasConstraintName("FK__Evento__FK_TipoE__59FA5E80");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao);

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Institui__AA57D6B401878241")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco)
                    .HasName("UQ__Institui__4DF3E1FF578CF0D0")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasia)
                    .HasName("UQ__Institui__F5389F31AEFE2676")
                    .IsUnique();

                entity.Property(e => e.IdInstituicao).HasColumnName("ID_Instituicao");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca);

                entity.Property(e => e.IdPresenca).HasColumnName("ID_Presenca");

                entity.Property(e => e.FkEvento).HasColumnName("FK_Evento");

                entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkEventoNavigation)
                    .WithMany(p => p.Presenca)
                    .HasForeignKey(d => d.FkEvento)
                    .HasConstraintName("FK__Presenca__FK_Eve__5DCAEF64");

                entity.HasOne(d => d.FkUsuarioNavigation)
                    .WithMany(p => p.Presenca)
                    .HasForeignKey(d => d.FkUsuario)
                    .HasConstraintName("FK__Presenca__FK_Usu__5CD6CB2B");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEvento);

                entity.HasIndex(e => e.TituloTipoEvento)
                    .HasName("UQ__TipoEven__40023AD2086C86A7")
                    .IsUnique();

                entity.Property(e => e.IdTipoEvento).HasColumnName("ID_TipoEvento");

                entity.Property(e => e.TituloTipoEvento)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.HasIndex(e => e.TituloTipoUsuario)
                    .HasName("UQ__TipoUsua__37BBE07E27CA0D68")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TipoUsuario");

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534DA487BEF")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkTipoUsuario).HasColumnName("FK_TipoUsuario");

                entity.Property(e => e.Genero)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.FkTipoUsuario)
                    .HasConstraintName("FK__Usuario__FK_Tipo__5535A963");
            });
        }
    }
}
