using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Band.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBandsIsActiveToTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Bands SET IsActive = 1;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Bands SET IsActive = 0;");
        }
    }
}
