using Microsoft.EntityFrameworkCore.Migrations;

namespace ATours.Repositories.EFCore.Migrations
{
    public partial class Dev003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Hotel");

            migrationBuilder.AlterColumn<double>(
                name: "Point",
                table: "Hotel",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotel",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_IdCliente",
                table: "Hotel",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Cliente_IdCliente",
                table: "Hotel",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Cliente_IdCliente",
                table: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_IdCliente",
                table: "Hotel");

            migrationBuilder.AlterColumn<int>(
                name: "Point",
                table: "Hotel",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Hotel",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");
        }
    }
}
