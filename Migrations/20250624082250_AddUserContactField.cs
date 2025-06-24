using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace woolly_friends.Migrations
{
    /// <inheritdoc />
    public partial class AddUserContactField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserContact",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserContact",
                table: "Users");
        }
    }
}
