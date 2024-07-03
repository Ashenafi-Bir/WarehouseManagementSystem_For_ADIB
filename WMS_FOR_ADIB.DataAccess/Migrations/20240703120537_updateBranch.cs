using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_FOR_ADIB.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_BranchID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "BranchID",
                table: "AspNetUsers",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_BranchID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_BranchId",
                table: "AspNetUsers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_BranchId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "AspNetUsers",
                newName: "BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_BranchId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_BranchID");

            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_BranchID",
                table: "AspNetUsers",
                column: "BranchID",
                principalTable: "Branches",
                principalColumn: "BranchID");
        }
    }
}
