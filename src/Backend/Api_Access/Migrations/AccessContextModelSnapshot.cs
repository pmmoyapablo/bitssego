﻿// <auto-generated />
using System;
using Api_Access.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Access.Migrations
{
    [DbContext(typeof(AccessContext))]
    partial class AccessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api_Access.Models.Access", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("creation_date");

                    b.Property<string>("description");

                    b.Property<int>("level");

                    b.HasKey("id");

                    b.ToTable("Sisg_Accessroles");
                });

            modelBuilder.Entity("Api_Access.Models.Menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("creation_date");

                    b.Property<int>("level");

                    b.Property<string>("name");

                    b.Property<int>("order");

                    b.Property<int>("parentId");

                    b.Property<string>("path_icon");

                    b.Property<string>("url");

                    b.Property<string>("view");

                    b.Property<int>("visible");

                    b.HasKey("id");

                    b.ToTable("Sisg_Menus");
                });

            modelBuilder.Entity("Api_Access.Models.Profile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("creation_date");

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Sisg_Profiles");
                });

            modelBuilder.Entity("Api_Access.Models.Rol", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accessId");

                    b.Property<DateTime>("creation_date");

                    b.Property<string>("description");

                    b.Property<int>("profileId");

                    b.HasKey("id");

                    b.ToTable("Sisg_Roles");
                });

            modelBuilder.Entity("Api_Access.Models.RolesMenu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuId");

                    b.Property<int>("RolId");

                    b.HasKey("id");

                    b.ToTable("Sisg_Rolesmenus");
                });

            modelBuilder.Entity("Api_Access.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("creation_date");

                    b.Property<int>("enable");

                    b.Property<string>("password");

                    b.Property<int>("rolId");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.ToTable("Sisg_Users");
                });
#pragma warning restore 612, 618
        }
    }
}
