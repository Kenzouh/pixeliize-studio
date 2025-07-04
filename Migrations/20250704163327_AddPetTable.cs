using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace woolly_friends.Migrations
{
    /// <inheritdoc />
    public partial class AddPetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    PetPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetBreed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetGender = table.Column<int>(type: "int", nullable: false),
                    PetDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PetLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetImgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
