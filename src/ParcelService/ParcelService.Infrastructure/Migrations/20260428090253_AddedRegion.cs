using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender_TerminalId",
                table: "Parcel",
                newName: "Sender_Terminal_Id");

            migrationBuilder.RenameColumn(
                name: "Receiver_TerminalId",
                table: "Parcel",
                newName: "Receiver_Terminal_Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Sender_Terminal_Id",
                table: "Parcel",
                newName: "Sender_TerminalId");

            migrationBuilder.RenameColumn(
                name: "Receiver_Terminal_Id",
                table: "Parcel",
                newName: "Receiver_TerminalId");
        }
    }
}
