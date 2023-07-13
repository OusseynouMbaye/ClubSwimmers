using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClubSwimmers.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), " 1223 Saint-foy Quebec , 4v5 7x9", "Canada", "NSh" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), " 255 saint-georges Beauce , G4Y 5D9", "Canada", "CNRB" }
                });

            migrationBuilder.InsertData(
                table: "Swimmers",
                columns: new[] { "SwimmerId", "Age", "ClubId", "Name", "TrainingGroup" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 7, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Amina Diop", "Initiation II" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 14, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Emile Bergeron", "Elite" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 22, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Sandra Bullock", "Master I" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Swimmers",
                keyColumn: "SwimmerId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Swimmers",
                keyColumn: "SwimmerId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Swimmers",
                keyColumn: "SwimmerId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "ClubId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "ClubId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
