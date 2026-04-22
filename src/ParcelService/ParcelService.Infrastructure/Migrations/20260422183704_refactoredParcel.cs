using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactoredParcel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination_Region",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Destination_Terminal",
                table: "Parcel");

            migrationBuilder.RenameColumn(
                name: "Sender_Name",
                table: "Parcel",
                newName: "Sender_PersonalInformation_Name");

            migrationBuilder.RenameColumn(
                name: "Sender_Address_ZipCode",
                table: "Parcel",
                newName: "Sender_PersonalInformation_Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Sender_Address_Street",
                table: "Parcel",
                newName: "Sender_PersonalInformation_Address_Street");

            migrationBuilder.RenameColumn(
                name: "Sender_Address_HouseNumber",
                table: "Parcel",
                newName: "Sender_PersonalInformation_Address_HouseNumber");

            migrationBuilder.RenameColumn(
                name: "Sender_Address_Country",
                table: "Parcel",
                newName: "Sender_PersonalInformation_Address_Country");

            migrationBuilder.RenameColumn(
                name: "Sender_Address_City",
                table: "Parcel",
                newName: "Sender_PersonalInformation_Address_City");

            migrationBuilder.RenameColumn(
                name: "Receiver_Name",
                table: "Parcel",
                newName: "Receiver_PersonalInformation_Name");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_ZipCode",
                table: "Parcel",
                newName: "Receiver_PersonalInformation_Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_Street",
                table: "Parcel",
                newName: "Receiver_PersonalInformation_Address_Street");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_HouseNumber",
                table: "Parcel",
                newName: "Receiver_PersonalInformation_Address_HouseNumber");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_Country",
                table: "Parcel",
                newName: "Receiver_PersonalInformation_Address_Country");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_City",
                table: "Parcel",
                newName: "Receiver_PersonalInformation_Address_City");

            migrationBuilder.AddColumn<Guid>(
                name: "Receiver_TerminalId",
                table: "Parcel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Sender_TerminalId",
                table: "Parcel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receiver_TerminalId",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "Sender_TerminalId",
                table: "Parcel");

            migrationBuilder.RenameColumn(
                name: "Sender_PersonalInformation_Name",
                table: "Parcel",
                newName: "Sender_Name");

            migrationBuilder.RenameColumn(
                name: "Sender_PersonalInformation_Address_ZipCode",
                table: "Parcel",
                newName: "Sender_Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Sender_PersonalInformation_Address_Street",
                table: "Parcel",
                newName: "Sender_Address_Street");

            migrationBuilder.RenameColumn(
                name: "Sender_PersonalInformation_Address_HouseNumber",
                table: "Parcel",
                newName: "Sender_Address_HouseNumber");

            migrationBuilder.RenameColumn(
                name: "Sender_PersonalInformation_Address_Country",
                table: "Parcel",
                newName: "Sender_Address_Country");

            migrationBuilder.RenameColumn(
                name: "Sender_PersonalInformation_Address_City",
                table: "Parcel",
                newName: "Sender_Address_City");

            migrationBuilder.RenameColumn(
                name: "Receiver_PersonalInformation_Name",
                table: "Parcel",
                newName: "Receiver_Name");

            migrationBuilder.RenameColumn(
                name: "Receiver_PersonalInformation_Address_ZipCode",
                table: "Parcel",
                newName: "Receiver_Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Receiver_PersonalInformation_Address_Street",
                table: "Parcel",
                newName: "Receiver_Address_Street");

            migrationBuilder.RenameColumn(
                name: "Receiver_PersonalInformation_Address_HouseNumber",
                table: "Parcel",
                newName: "Receiver_Address_HouseNumber");

            migrationBuilder.RenameColumn(
                name: "Receiver_PersonalInformation_Address_Country",
                table: "Parcel",
                newName: "Receiver_Address_Country");

            migrationBuilder.RenameColumn(
                name: "Receiver_PersonalInformation_Address_City",
                table: "Parcel",
                newName: "Receiver_Address_City");

            migrationBuilder.AddColumn<string>(
                name: "Destination_Region",
                table: "Parcel",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Destination_Terminal",
                table: "Parcel",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
