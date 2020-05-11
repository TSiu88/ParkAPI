using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    NumberParks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                    table.ForeignKey(
                        name: "FK_Parks_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Name", "NumberParks" },
                values: new object[,]
                {
                    { 1, "California", 4 },
                    { 2, "Washington", 3 },
                    { 3, "Wyoming", 1 },
                    { 4, "Hawaii", 1 }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "Location", "Name", "StateId", "Type" },
                values: new object[,]
                {
                    { 1, "Forest of Redwooods", "Del Norte", "Redwood National Park", 1, "national" },
                    { 2, "Rock Monaliths", "Salinas Valley", "Pinnacles National Park", 1, "national" },
                    { 3, "Forest of Sequoias", "Visalia", "Sequoia National Park", 1, "national" },
                    { 4, "Mountain of Diablo Range", "Contra Costa", "Mount Diablo State Park", 1, "state" },
                    { 5, "Many ecosystems", "Olympic Penninsula", "Olympic National Park", 2, "national" },
                    { 6, "Cascades Mountain", "Snohomish County", "Mount Pilchuck State Park", 2, "state" },
                    { 9, "Recreational activities, camping", "Leavenworth", "Lake Wenatchee State Park", 2, "state" },
                    { 7, "First national park", "Wyoming, Montana, Idaho", "Yellowstone National Park", 3, "national" },
                    { 8, "Tide pools, caves, water tubes", "Maui", "Waianapanapa State Park", 4, "state" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parks_StateId",
                table: "Parks",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
