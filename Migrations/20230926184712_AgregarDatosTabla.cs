using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Magic_Villa_7.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDatosTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "ID", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la villa...", new DateTime(2023, 9, 26, 11, 47, 12, 751, DateTimeKind.Local).AddTicks(3447), new DateTime(2023, 9, 26, 11, 47, 12, 751, DateTimeKind.Local).AddTicks(3457), "", 50, "Villa Real", 5, 200.0 },
                    { 2, "", "Detalle de la villa...", new DateTime(2023, 9, 26, 11, 47, 12, 751, DateTimeKind.Local).AddTicks(3459), new DateTime(2023, 9, 26, 11, 47, 12, 751, DateTimeKind.Local).AddTicks(3459), "", 20, "Villa Los Campos", 6, 500.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
