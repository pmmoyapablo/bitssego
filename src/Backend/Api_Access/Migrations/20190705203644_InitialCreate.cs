using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Access.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sisg_Accessroles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    level = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Accessroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_Menus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    parentId = table.Column<int>(nullable: false),
                    view = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    order = table.Column<int>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    visible = table.Column<int>(nullable: false),
                    path_icon = table.Column<string>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Menus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_Profiles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_Roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    accessId = table.Column<int>(nullable: false),
                    profileId = table.Column<int>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_Rolesmenus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuId = table.Column<int>(nullable: false),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Rolesmenus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sisg_Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rolId = table.Column<int>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    enable = table.Column<int>(nullable: false),
                    creation_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sisg_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sisg_Accessroles");

            migrationBuilder.DropTable(
                name: "Sisg_Menus");

            migrationBuilder.DropTable(
                name: "Sisg_Profiles");

            migrationBuilder.DropTable(
                name: "Sisg_Roles");

            migrationBuilder.DropTable(
                name: "Sisg_Rolesmenus");

            migrationBuilder.DropTable(
                name: "Sisg_Users");
        }
    }
}
