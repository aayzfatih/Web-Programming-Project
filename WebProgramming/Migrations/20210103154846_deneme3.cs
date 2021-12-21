using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProje5.Migrations
{
    public partial class deneme3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciID",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_KullaniciID",
                table: "Blogs",
                column: "KullaniciID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Kullanicis_KullaniciID",
                table: "Blogs",
                column: "KullaniciID",
                principalTable: "Kullanicis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Kullanicis_KullaniciID",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_KullaniciID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "KullaniciID",
                table: "Blogs");
        }
    }
}
