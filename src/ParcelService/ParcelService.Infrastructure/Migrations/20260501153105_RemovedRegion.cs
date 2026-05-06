using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receiver_Terminal_Region_Country",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Receiver_Terminal_Region_MainRegion",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Receiver_Terminal_Region_SubRegion",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Sender_Terminal_Region_Country",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Sender_Terminal_Region_MainRegion",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Sender_Terminal_Region_SubRegion",
                table: "Parcel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Receiver_Terminal_Region_Country",
                table: "Parcel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Receiver_Terminal_Region_MainRegion",
                table: "Parcel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Receiver_Terminal_Region_SubRegion",
                table: "Parcel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sender_Terminal_Region_Country",
                table: "Parcel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sender_Terminal_Region_MainRegion",
                table: "Parcel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sender_Terminal_Region_SubRegion",
                table: "Parcel",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
