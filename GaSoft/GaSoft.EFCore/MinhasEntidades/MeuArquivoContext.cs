using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GaSoft.EFCore.MinhasEntidades;

public partial class MeuArquivoContext : DbContext
{
    public MeuArquivoContext()
    {
    }

    public MeuArquivoContext(DbContextOptions<MeuArquivoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<FuncionarioDetalhe> FuncionarioDetalhes { get; set; }

    public virtual DbSet<FuncionariosProjeto> FuncionariosProjetos { get; set; }

    public virtual DbSet<Projeto> Projetos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=gasoftdatabase2;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_clientes");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Email, "ix_clientes_email").IsUnique();

            entity.HasIndex(e => e.Nome, "ix_clientes_nome");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo).HasColumnName("ativo");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_departamentos");

            entity.ToTable("departamentos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_funcionarios");

            entity.ToTable("funcionarios");

            entity.HasIndex(e => e.DepartamentoId, "ix_funcionarios_departamento_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cargo)
                .HasMaxLength(100)
                .HasColumnName("cargo");
            entity.Property(e => e.DataContratacao).HasColumnName("data_contratacao");
            entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salario");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("fk_funcionarios_departamentos_departamento_id");
        });

        modelBuilder.Entity<FuncionarioDetalhe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_funcionario_detalhes");

            entity.ToTable("funcionario_detalhes");

            entity.HasIndex(e => e.FuncionarioId, "ix_funcionario_detalhes_funcionario_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .HasColumnName("celular");
            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .HasColumnName("cpf");
            entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            entity.Property(e => e.EnderecoResidencial)
                .HasMaxLength(200)
                .HasColumnName("endereco_residencial");
            entity.Property(e => e.Escolaridade).HasColumnName("escolaridade");
            entity.Property(e => e.EstadoCivil).HasColumnName("estado_civil");
            entity.Property(e => e.Foto)
                .HasMaxLength(200)
                .HasColumnName("foto");
            entity.Property(e => e.FuncionarioId).HasColumnName("funcionario_id");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.Nacionalidade)
                .HasMaxLength(50)
                .HasColumnName("nacionalidade");

            entity.HasOne(d => d.Funcionario).WithOne(p => p.FuncionarioDetalhe)
                .HasForeignKey<FuncionarioDetalhe>(d => d.FuncionarioId)
                .HasConstraintName("fk_funcionario_detalhes_funcionarios_funcionario_id");
        });

        modelBuilder.Entity<FuncionariosProjeto>(entity =>
        {
            entity.HasKey(e => new { e.FuncionarioId, e.ProjetoId }).HasName("pk_funcionarios_projetos");

            entity.ToTable("funcionarios_projetos");

            entity.HasIndex(e => e.ProjetoId, "ix_funcionarios_projetos_projeto_id");

            entity.Property(e => e.FuncionarioId).HasColumnName("funcionario_id");
            entity.Property(e => e.ProjetoId).HasColumnName("projeto_id");
            entity.Property(e => e.HorasTrabalhadas).HasColumnName("horas_trabalhadas");

            entity.HasOne(d => d.Funcionario).WithMany(p => p.FuncionariosProjetos)
                .HasForeignKey(d => d.FuncionarioId)
                .HasConstraintName("fk_funcionarios_projetos_funcionarios_funcionario_id");

            entity.HasOne(d => d.Projeto).WithMany(p => p.FuncionariosProjetos)
                .HasForeignKey(d => d.ProjetoId)
                .HasConstraintName("fk_funcionarios_projetos_projetos_projeto_id");
        });

        modelBuilder.Entity<Projeto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_projetos");

            entity.ToTable("projetos");

            entity.HasIndex(e => e.ClienteId, "ix_projetos_cliente_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.DataAtualizacao).HasColumnName("data_atualizacao");
            entity.Property(e => e.DataFim).HasColumnName("data_fim");
            entity.Property(e => e.DataInicio).HasColumnName("data_inicio");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Orcamento)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("orcamento");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Projetos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("fk_projetos_clientes_cliente_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
