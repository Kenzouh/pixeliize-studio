using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace woolly_friends.Migrations
{
    /// <inheritdoc />
    public partial class AddDateCreatedAndRemoveUserAddressFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
