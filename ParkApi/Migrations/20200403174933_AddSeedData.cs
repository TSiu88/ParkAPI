using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkApi.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "StateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "StateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "StateId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "StateId",
                keyValue: 4);
        }
    }
}
