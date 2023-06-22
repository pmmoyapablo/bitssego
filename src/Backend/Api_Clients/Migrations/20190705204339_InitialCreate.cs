using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Clients.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sisg_Distributors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idSA = table.Column<int>(nullable: false),
                    rif = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    represent = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    nit = table.Column<string>(nullable: true),
                    codeZone = table.Column<string>(nullable: true),
                    nameSeller = table.Column<string>(nullable: true),
                    rifSeller = table.Column<string>(nullable: true),
                    phoneSeller = table.Column<string>(nullable: true),
                    typeAgreement = table.Column<string>(nullable: true),
                    enable = table.Column<int>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Distributors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_DistributorsProviders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistributorsId = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_DistributorsProviders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_DistributorsUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistributorsId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_DistributorsUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_Providers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rif = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_Technicians",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rif = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    enable = table.Column<int>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Technicians", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_TechniciansDistributors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    techniciansId = table.Column<int>(nullable: false),
                    distributorsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_TechniciansDistributors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_TechniciansUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    techniciansId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_TechniciansUsers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sisg_Distributors");

            migrationBuilder.DropTable(
                name: "Sisg_DistributorsProviders");

            migrationBuilder.DropTable(
                name: "Sisg_DistributorsUsers");

            migrationBuilder.DropTable(
                name: "Sisg_Providers");

            migrationBuilder.DropTable(
                name: "Sisg_Technicians");

            migrationBuilder.DropTable(
                name: "Sisg_TechniciansDistributors");

            migrationBuilder.DropTable(
                name: "Sisg_TechniciansUsers");
        }
    }
}
