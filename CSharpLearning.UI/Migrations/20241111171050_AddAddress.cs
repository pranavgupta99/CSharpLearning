using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpLearning.UI.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermanentAddressId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_PermanentAddressId",
                table: "Students",
                column: "PermanentAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Address_PermanentAddressId",
                table: "Students",
                column: "PermanentAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Address_PermanentAddressId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Students_PermanentAddressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermanentAddressId",
                table: "Students");
        }
    }
}
