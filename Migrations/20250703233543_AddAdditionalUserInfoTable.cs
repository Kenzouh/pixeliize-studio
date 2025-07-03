using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace woolly_friends.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalUserInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalUserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalUserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalUserInfo_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalUserInfo");
        }
    }
}
