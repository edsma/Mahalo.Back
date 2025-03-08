using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahalo.Back.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationsForTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourcesDisorder_Resources_ResourceId",
                table: "ResourcesDisorder");

            migrationBuilder.DropIndex(
                name: "IX_ResourcesDisorder_ResourceId",
                table: "ResourcesDisorder");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "ResourcesDisorder");

            migrationBuilder.AddColumn<int>(
                name: "ResourceDisorderId",
                table: "Resources",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceDisorderId",
                table: "Resources",
                column: "ResourceDisorderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_ResourcesDisorder_ResourceDisorderId",
                table: "Resources",
                column: "ResourceDisorderId",
                principalTable: "ResourcesDisorder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_ResourcesDisorder_ResourceDisorderId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ResourceDisorderId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ResourceDisorderId",
                table: "Resources");

            migrationBuilder.AddColumn<int>(
                name: "ResourceId",
                table: "ResourcesDisorder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResourcesDisorder_ResourceId",
                table: "ResourcesDisorder",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcesDisorder_Resources_ResourceId",
                table: "ResourcesDisorder",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
