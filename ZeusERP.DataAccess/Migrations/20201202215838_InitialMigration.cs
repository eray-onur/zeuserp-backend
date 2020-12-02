using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeusERP.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    JobPosition = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WebsiteLink = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    ExtraInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 75, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    SubcategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_product_boms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    BoMTypeId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    ComponentsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_product_boms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_product_boms_comps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoMId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_product_boms_comps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_inv_products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    BarcodeNumber = table.Column<string>(nullable: true),
                    UnitCount = table.Column<decimal>(nullable: false),
                    UnitCost = table.Column<decimal>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    BillOfMaterialsId = table.Column<int>(nullable: false),
                    CanBePurchased = table.Column<bool>(nullable: false),
                    CanBeSold = table.Column<bool>(nullable: false),
                    ResponsibleId = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    BoMId = table.Column<int>(nullable: false),
                    ImgPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_inv_products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_contacts");

            migrationBuilder.DropTable(
                name: "t_inv_categories");

            migrationBuilder.DropTable(
                name: "t_inv_product_boms");

            migrationBuilder.DropTable(
                name: "t_inv_product_boms_comps");

            migrationBuilder.DropTable(
                name: "t_inv_products");
        }
    }
}
