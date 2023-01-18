﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RadarG6.Context;

#nullable disable

namespace Radar2._0G6webAPI.Migrations
{
    [DbContext(typeof(RadarContexto))]
    partial class RadarContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RadarWebApi.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Permissao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("RadarWebApi.Models.Campanha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Data");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Descricao");

                    b.Property<string>("Foto")
                        .HasColumnType("longtext")
                        .HasColumnName("Foto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Campanha");
                });

            modelBuilder.Entity("RadarWebApi.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Bairro");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Cidade");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Complemento");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CPF");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Email");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Estado");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Logradouro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Numero");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext")
                        .HasColumnName("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RadarWebApi.Models.Loja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Bairro");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CEP");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Cidade");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Complemento");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Estado");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Latitude");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Logradouro");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Longitude");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Numero");

                    b.Property<string>("Observacao")
                        .HasColumnType("longtext")
                        .HasColumnName("Observacao");

                    b.HasKey("Id");

                    b.ToTable("Loja");
                });

            modelBuilder.Entity("RadarWebApi.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("CLienteId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ClietneId");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataPedido");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double")
                        .HasColumnName("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("RadarWebApi.Models.PedidoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("PedidoId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Pedido");

                    b.Property<int?>("PedidoId1")
                        .HasColumnType("int");

                    b.Property<string>("ProdutoId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Produto");

                    b.Property<int?>("ProdutoId1")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<double>("Valor")
                        .HasColumnType("double")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId1");

                    b.HasIndex("ProdutoId1");

                    b.ToTable("PedidoProduto");
                });

            modelBuilder.Entity("RadarWebApi.Models.PosicaoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("CampanhaId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Campanha");

                    b.Property<int?>("CampanhaId1")
                        .HasColumnType("int");

                    b.Property<string>("PosicaoX")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PosicaoX");

                    b.Property<string>("PosicaoY")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PosicaoY");

                    b.HasKey("Id");

                    b.HasIndex("CampanhaId1");

                    b.ToTable("PosicoesProdutos");
                });

            modelBuilder.Entity("RadarWebApi.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadeEstoque");

                    b.Property<double>("Valor")
                        .HasColumnType("double")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("RadarWebApi.Models.Pedido", b =>
                {
                    b.HasOne("RadarWebApi.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("RadarWebApi.Models.PedidoProduto", b =>
                {
                    b.HasOne("RadarWebApi.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId1");

                    b.HasOne("RadarWebApi.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId1");

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("RadarWebApi.Models.PosicaoProduto", b =>
                {
                    b.HasOne("RadarWebApi.Models.Campanha", "Campanha")
                        .WithMany()
                        .HasForeignKey("CampanhaId1");

                    b.Navigation("Campanha");
                });
#pragma warning restore 612, 618
        }
    }
}
