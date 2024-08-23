using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketGovernorateCityDistrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Governorate",
                table: "Tickets",
                newName: "GovernorateName");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "Tickets",
                newName: "DistrictName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Tickets",
                newName: "CityName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GovernorateName",
                table: "Tickets",
                newName: "Governorate");

            migrationBuilder.RenameColumn(
                name: "DistrictName",
                table: "Tickets",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Tickets",
                newName: "City");
        }
    }
}
