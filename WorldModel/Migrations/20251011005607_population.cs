using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldModel.Migrations
{
    /// <inheritdoc />
    public partial class population : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "population",
                table: "cities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "population",
                table: "cities");
        }
    }
}
