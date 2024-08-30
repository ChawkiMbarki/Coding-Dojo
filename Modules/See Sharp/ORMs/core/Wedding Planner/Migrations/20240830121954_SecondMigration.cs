using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wedding_Planner.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVP_Users_UserId",
                table: "RSVP");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVP_Wedding_WeddingId",
                table: "RSVP");

            migrationBuilder.DropForeignKey(
                name: "FK_Wedding_Users_PlannerId",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVP",
                table: "RSVP");

            migrationBuilder.RenameTable(
                name: "Wedding",
                newName: "Weddings");

            migrationBuilder.RenameTable(
                name: "RSVP",
                newName: "RSVPs");

            migrationBuilder.RenameIndex(
                name: "IX_Wedding_PlannerId",
                table: "Weddings",
                newName: "IX_Weddings_PlannerId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVP_WeddingId",
                table: "RSVPs",
                newName: "IX_RSVPs_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVP_UserId",
                table: "RSVPs",
                newName: "IX_RSVPs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVPs",
                table: "RSVPs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_Users_UserId",
                table: "RSVPs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_Weddings_WeddingId",
                table: "RSVPs",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_PlannerId",
                table: "Weddings",
                column: "PlannerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_Users_UserId",
                table: "RSVPs");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_Weddings_WeddingId",
                table: "RSVPs");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_PlannerId",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVPs",
                table: "RSVPs");

            migrationBuilder.RenameTable(
                name: "Weddings",
                newName: "Wedding");

            migrationBuilder.RenameTable(
                name: "RSVPs",
                newName: "RSVP");

            migrationBuilder.RenameIndex(
                name: "IX_Weddings_PlannerId",
                table: "Wedding",
                newName: "IX_Wedding_PlannerId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPs_WeddingId",
                table: "RSVP",
                newName: "IX_RSVP_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPs_UserId",
                table: "RSVP",
                newName: "IX_RSVP_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVP",
                table: "RSVP",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVP_Users_UserId",
                table: "RSVP",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVP_Wedding_WeddingId",
                table: "RSVP",
                column: "WeddingId",
                principalTable: "Wedding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wedding_Users_PlannerId",
                table: "Wedding",
                column: "PlannerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
