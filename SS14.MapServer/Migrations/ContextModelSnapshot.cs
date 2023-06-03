﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SS14.MapServer.Models;
using SS14.MapServer.Models.Types;

#nullable disable

namespace SS14.MapServer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SS14.MapServer.Models.Entities.Grid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("GridId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("MapGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TileSize")
                        .HasColumnType("integer");

                    b.Property<bool>("Tiled")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("MapGuid");

                    b.ToTable("Grid");
                });

            modelBuilder.Entity("SS14.MapServer.Models.Entities.ImageFile", b =>
                {
                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("InternalPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Path");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("SS14.MapServer.Models.Entities.Map", b =>
                {
                    b.Property<Guid>("MapGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Attribution")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GitRef")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("MapId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<ParallaxLayer>>("ParallaxLayers")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("MapGuid");

                    b.HasIndex("GitRef");

                    b.HasIndex("GitRef", "MapId");

                    b.ToTable("Map");
                });

            modelBuilder.Entity("SS14.MapServer.Models.Entities.Tile", b =>
                {
                    b.Property<Guid>("MapGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("GridId")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("MapGuid", "GridId", "X", "Y");

                    b.HasIndex("MapGuid", "GridId");

                    b.ToTable("Tile");
                });

            modelBuilder.Entity("SS14.MapServer.Models.Entities.Grid", b =>
                {
                    b.HasOne("SS14.MapServer.Models.Entities.Map", null)
                        .WithMany("Grids")
                        .HasForeignKey("MapGuid");

                    b.OwnsOne("SS14.MapServer.Models.Types.Point", "Offset", b1 =>
                        {
                            b1.Property<Guid>("GridId")
                                .HasColumnType("uuid");

                            b1.Property<float>("X")
                                .HasColumnType("real");

                            b1.Property<float>("Y")
                                .HasColumnType("real");

                            b1.HasKey("GridId");

                            b1.ToTable("Grid");

                            b1.WithOwner()
                                .HasForeignKey("GridId");
                        });

                    b.OwnsOne("SS14.MapServer.Models.Types.Area", "Extent", b1 =>
                        {
                            b1.Property<Guid>("GridId")
                                .HasColumnType("uuid");

                            b1.HasKey("GridId");

                            b1.ToTable("Grid");

                            b1.WithOwner()
                                .HasForeignKey("GridId");

                            b1.OwnsOne("SS14.MapServer.Models.Types.Point", "A", b2 =>
                                {
                                    b2.Property<Guid>("AreaGridId")
                                        .HasColumnType("uuid");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.HasKey("AreaGridId");

                                    b2.ToTable("Grid");

                                    b2.WithOwner()
                                        .HasForeignKey("AreaGridId");
                                });

                            b1.OwnsOne("SS14.MapServer.Models.Types.Point", "B", b2 =>
                                {
                                    b2.Property<Guid>("AreaGridId")
                                        .HasColumnType("uuid");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.HasKey("AreaGridId");

                                    b2.ToTable("Grid");

                                    b2.WithOwner()
                                        .HasForeignKey("AreaGridId");
                                });

                            b1.Navigation("A")
                                .IsRequired();

                            b1.Navigation("B")
                                .IsRequired();
                        });

                    b.Navigation("Extent")
                        .IsRequired();

                    b.Navigation("Offset")
                        .IsRequired();
                });

            modelBuilder.Entity("SS14.MapServer.Models.Entities.Map", b =>
                {
                    b.Navigation("Grids");
                });
#pragma warning restore 612, 618
        }
    }
}
