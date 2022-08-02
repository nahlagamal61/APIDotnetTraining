using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIDotnetTraining.Migrations
{
    public partial class AddReader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Readers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReaderID",
                table: "Readers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "ID", "Age", "BookId", "Name", "ReaderID" },
                values: new object[] { 1, 22, 1, "reader 1", null });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "ID", "Age", "BookId", "Name", "ReaderID" },
                values: new object[] { 2, 44, 2, "reader 1", null });

            migrationBuilder.CreateIndex(
                name: "IX_Readers_ReaderID",
                table: "Readers",
                column: "ReaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Readers_Readers_ReaderID",
                table: "Readers",
                column: "ReaderID",
                principalTable: "Readers",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readers_Readers_ReaderID",
                table: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Readers_ReaderID",
                table: "Readers");

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "ReaderID",
                table: "Readers");
        }
    }
}
