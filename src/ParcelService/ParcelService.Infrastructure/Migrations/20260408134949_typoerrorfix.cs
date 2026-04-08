using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class typoerrorfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Receiver_Name",
                table: "Parcel",
                newName: "Reciever_Name");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_ZipCode",
                table: "Parcel",
                newName: "Reciever_Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_Street",
                table: "Parcel",
                newName: "Reciever_Address_Street");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_HouseNumber",
                table: "Parcel",
                newName: "Reciever_Address_HouseNumber");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_Country",
                table: "Parcel",
                newName: "Reciever_Address_Country");

            migrationBuilder.RenameColumn(
                name: "Receiver_Address_City",
                table: "Parcel",
                newName: "Reciever_Address_City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reciever_Name",
                table: "Parcel",
                newName: "Receiver_Name");

            migrationBuilder.RenameColumn(
                name: "Reciever_Address_ZipCode",
                table: "Parcel",
                newName: "Receiver_Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Reciever_Address_Street",
                table: "Parcel",
                newName: "Receiver_Address_Street");

            migrationBuilder.RenameColumn(
                name: "Reciever_Address_HouseNumber",
                table: "Parcel",
                newName: "Receiver_Address_HouseNumber");

            migrationBuilder.RenameColumn(
                name: "Reciever_Address_Country",
                table: "Parcel",
                newName: "Receiver_Address_Country");

            migrationBuilder.RenameColumn(
                name: "Reciever_Address_City",
                table: "Parcel",
                newName: "Receiver_Address_City");
        }
    }
}
