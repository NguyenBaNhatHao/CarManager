using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TuyenDuong",
                columns: table => new
                {
                    TuyenDuongId = table.Column<int>(type: "int", nullable: false),
                    QuangDuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemBD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiemKT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuyenDuong", x => x.TuyenDuongId);
                });

            migrationBuilder.CreateTable(
                name: "tb_xe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenXe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BienSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiTrong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuyenDuongId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_xe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_xe_TuyenDuong_TuyenDuongId",
                        column: x => x.TuyenDuongId,
                        principalTable: "TuyenDuong",
                        principalColumn: "TuyenDuongId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_xe_TuyenDuongId",
                table: "tb_xe",
                column: "TuyenDuongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_xe");

            migrationBuilder.DropTable(
                name: "TuyenDuong");
        }
    }
}
