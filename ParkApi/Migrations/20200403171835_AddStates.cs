using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkApi.Migrations
{
    public partial class AddStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parks_State_StateId",
                table: "Parks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parks_States_StateId",
                table: "Parks",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parks_States_StateId",
                table: "Parks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parks_State_StateId",
                table: "Parks",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
