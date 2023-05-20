using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "City", "CustomerName", "DateOfBirth", "Email", "Gender", "PhoneNumber", "Province", "StreetAddress" },
                values: new object[] { 2, "Alasehir", "Husnu", null, "husnu.cemre@gmail.com", null, "5344181168", "Manisa", "Yenice mah Sumer Oral cad no 23" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);
        }
    }
}
