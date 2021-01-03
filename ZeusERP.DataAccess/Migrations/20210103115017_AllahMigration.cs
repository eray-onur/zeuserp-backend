using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeusERP.DataAccess.Migrations
{
    public partial class AllahMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BoMType",
                table: "t_inv_product_boms",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "t_plm_eco_tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ColorCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_plm_eco_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_plm_eco_types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EmailAlias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_plm_eco_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_plm_ecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(nullable: true),
                    ResponsibleId = table.Column<int>(nullable: false),
                    ApplyOn = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Effectivity = table.Column<bool>(nullable: false),
                    EffectivityDate = table.Column<DateTime>(nullable: false),
                    ECOTagsId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ApproverId = table.Column<int>(nullable: false),
                    EcoStage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_plm_ecos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_plm_eco_tags");

            migrationBuilder.DropTable(
                name: "t_plm_eco_types");

            migrationBuilder.DropTable(
                name: "t_plm_ecos");

            migrationBuilder.AlterColumn<int>(
                name: "BoMType",
                table: "t_inv_product_boms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
