using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotelreservation.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ReservationRequests");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "ReservationRequests",
                newName: "RoomNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomNo",
                table: "ReservationRequests",
                newName: "RoomId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ReservationRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
