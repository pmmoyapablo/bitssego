﻿// <auto-generated />
using System;
using Api_Clients.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Clients.Migrations
{
    [DbContext(typeof(ClientsContext))]
    partial class ClientsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api_Clients.Models.Distributor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("codeZone");

                    b.Property<string>("country");

                    b.Property<DateTime>("creation_date");

                    b.Property<string>("description");

                    b.Property<string>("email");

                    b.Property<int>("enable");

                    b.Property<int>("idSA");

                    b.Property<string>("nameSeller");

                    b.Property<string>("nit");

                    b.Property<string>("phone");

                    b.Property<string>("phoneSeller");

                    b.Property<string>("represent");

                    b.Property<string>("rif");

                    b.Property<string>("rifSeller");

                    b.Property<string>("state");

                    b.Property<string>("typeAgreement");

                    b.HasKey("id");

                    b.ToTable("Sisg_Distributors");
                });

            modelBuilder.Entity("Api_Clients.Models.DistributorsProvider", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistributorsId");

                    b.Property<int>("ProviderId");

                    b.HasKey("id");

                    b.ToTable("Sisg_DistributorsProviders");
                });

            modelBuilder.Entity("Api_Clients.Models.DistributorsUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistributorsId");

                    b.Property<int>("UserId");

                    b.HasKey("id");

                    b.ToTable("Sisg_DistributorsUsers");
                });

            modelBuilder.Entity("Api_Clients.Models.Provider", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address");

                    b.Property<DateTime>("creation_date");

                    b.Property<string>("description");

                    b.Property<string>("email");

                    b.Property<string>("image");

                    b.Property<string>("phone");

                    b.Property<string>("rif");

                    b.HasKey("id");

                    b.ToTable("Sisg_Providers");
                });

            modelBuilder.Entity("Api_Clients.Models.Technician", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address");

                    b.Property<DateTime>("creation_date");

                    b.Property<string>("description");

                    b.Property<string>("email");

                    b.Property<int>("enable");

                    b.Property<string>("phone");

                    b.Property<string>("rif");

                    b.HasKey("id");

                    b.ToTable("Sisg_Technicians");
                });

            modelBuilder.Entity("Api_Clients.Models.TechniciansDistributor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("distributorsId");

                    b.Property<int>("techniciansId");

                    b.HasKey("id");

                    b.ToTable("Sisg_TechniciansDistributors");
                });

            modelBuilder.Entity("Api_Clients.Models.TechniciansUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("techniciansId");

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.ToTable("Sisg_TechniciansUsers");
                });
#pragma warning restore 612, 618
        }
    }
}