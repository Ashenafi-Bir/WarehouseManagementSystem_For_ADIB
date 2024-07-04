using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_FOR_ADIB.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateModels123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PurchaseRequisitions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PurchaseRequisitions");
        }
    }
}
