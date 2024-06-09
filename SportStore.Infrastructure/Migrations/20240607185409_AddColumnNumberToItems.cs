using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnNumberToItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Items");
        }
    }
}
