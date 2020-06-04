using Microsoft.EntityFrameworkCore.Migrations;

namespace MoscowTransport.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NameFacilities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeofSportsGround = table.Column<string>(nullable: true),
                    AdministrativeDistrict = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NumberPhone = table.Column<string>(nullable: true),
                    Lighting = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameFacilities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NameFacilities",
                columns: new[] { "Id", "Address", "AdministrativeDistrict", "Area", "Email", "Lighting", "Name", "NumberPhone", "TypeofSportsGround", "WebSite" },
                values: new object[] { 1L, "Олонецкий проезд, дом 6", "Северо-Восточный административный округ", "Бутырский район", "1095@edu.mos.ru", "без дополнительного освещения", "универсальная спортивная площадка", "(495) 470-91-55", "специальное покрытие", "sch1095sv.mskobr.ru" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NameFacilities");
        }
    }
}
