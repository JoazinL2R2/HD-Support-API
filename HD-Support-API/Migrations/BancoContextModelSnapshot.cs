﻿// <auto-generated />
using System;
using HD_Support_API.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HD_Support_API.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HD_Support_API.Models.Conversa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Criptografia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_conclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FuncionariosId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TipoConversa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionariosId");

                    b.ToTable("Conversa");
                });

            modelBuilder.Entity("HD_Support_API.Models.Emprestimos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EquipamentosId")
                        .HasColumnType("int");

                    b.Property<int>("FuncionariosId")
                        .HasColumnType("int");

                    b.Property<string>("profissional_HD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipamentosId");

                    b.HasIndex("FuncionariosId");

                    b.ToTable("Emprestimo");
                });

            modelBuilder.Entity("HD_Support_API.Models.Equipamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtEmeprestimoFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtEmeprestimoInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("HeadSet")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("IdPatrimonio")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Processador")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SistemaOperacional")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("profissional_HD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("statusEquipamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("HD_Support_API.Models.Funcionarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StatusFuncionario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telegram")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("profissional_HD")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("HD_Support_API.Models.HelpDesk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("StatusConversa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HelpDesk");
                });

            modelBuilder.Entity("HD_Support_API.Models.Mensagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConversaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_envio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("HD_Support_API.Models.Conversa", b =>
                {
                    b.HasOne("HD_Support_API.Models.HelpDesk", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HD_Support_API.Models.HelpDesk", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HD_Support_API.Models.Emprestimos", b =>
                {
                    b.HasOne("HD_Support_API.Models.Equipamentos", "Equipamento")
                        .WithMany()
                        .HasForeignKey("EquipamentosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HD_Support_API.Models.Funcionarios", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("HD_Support_API.Models.Mensagens", b =>
                {
                    b.HasOne("HD_Support_API.Models.HelpDesk", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
