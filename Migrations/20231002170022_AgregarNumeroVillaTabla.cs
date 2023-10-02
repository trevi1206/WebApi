using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic_Villa_7.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVillaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumeroVillas",
                columns: table => new
                {
                    Villa_No = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroVillas", x => x.Villa_No);
                    table.ForeignKey(
                        name: "FK_NumeroVillas_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 10, 2, 10, 0, 22, 300, DateTimeKind.Local).AddTicks(5127), new DateTime(2023, 10, 2, 10, 0, 22, 300, DateTimeKind.Local).AddTicks(5136) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 10, 2, 10, 0, 22, 300, DateTimeKind.Local).AddTicks(5138), new DateTime(2023, 10, 2, 10, 0, 22, 300, DateTimeKind.Local).AddTicks(5139) });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroVillas_VillaId",
                table: "NumeroVillas",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroVillas");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 26, 11, 47, 12, 751, DateTimeKind.Local).AddTicks(3447), new DateTime(2023, 9, 26, 11, 47, 12, 751, DateTimeKind.Local).AddTicks(3457) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 26, 11, 47, 12, 751, DateTimeKind.Local).AddTicks(3459), new DateTime(2023, 9, 26, 11, 47, 12, 751, DateTimeKind.Local).AddTicks(3459) });
        }
    }
}
