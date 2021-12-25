using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProje5.Migrations
{
    public partial class deneme4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kullaniciBlogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullaniciBlogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_kullaniciBlogs_Kullanicis_KisiID",
                        column: x => x.KisiID,
                        principalTable: "Kullanicis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kullaniciBlogs_KisiID",
                table: "kullaniciBlogs",
                column: "KisiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kullaniciBlogs");
        }
    }
}
