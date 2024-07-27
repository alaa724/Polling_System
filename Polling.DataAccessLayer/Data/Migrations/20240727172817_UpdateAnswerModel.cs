using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polling.DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnswerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Answers");
        }
    }
}
