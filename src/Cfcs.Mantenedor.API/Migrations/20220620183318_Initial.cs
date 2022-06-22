using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cfcs.Mantenedor.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Codigo = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    NombreOficial = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    CodigoLibroClaseElectronico = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Codigo = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Letra = table.Column<string>(type: "character(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    RegionCodigo = table.Column<short>(type: "smallint", nullable: false),
                    Codigo = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => new { x.RegionCodigo, x.Codigo });
                    table.ForeignKey(
                        name: "FK_Ciudad_Region",
                        column: x => x.RegionCodigo,
                        principalTable: "Region",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comuna",
                columns: table => new
                {
                    RegionCodigo = table.Column<short>(type: "smallint", nullable: false),
                    CiudadCodigo = table.Column<short>(type: "smallint", nullable: false),
                    Codigo = table.Column<short>(type: "smallint", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    CodigoPostal = table.Column<int>(type: "integer", nullable: false),
                    CodigoLibroClaseElectronico = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuna", x => new { x.RegionCodigo, x.CiudadCodigo, x.Codigo });
                    table.ForeignKey(
                        name: "FK_Comuna_Ciudad",
                        columns: x => new { x.RegionCodigo, x.CiudadCodigo },
                        principalTable: "Ciudad",
                        principalColumns: new[] { "RegionCodigo", "Codigo" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Run = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    RunCuerpo = table.Column<int>(type: "integer", nullable: false),
                    RunDigito = table.Column<string>(type: "character(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(95)", unicode: false, maxLength: 95, nullable: true),
                    Nombres = table.Column<string>(type: "character varying(45)", unicode: false, maxLength: 45, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "character varying(25)", unicode: false, maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    SexoCodigo = table.Column<short>(type: "smallint", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    RegionCodigo = table.Column<short>(type: "smallint", nullable: true),
                    CiudadCodigo = table.Column<short>(type: "smallint", nullable: true),
                    ComunaCodigo = table.Column<short>(type: "smallint", nullable: true),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<int>(type: "integer", nullable: true),
                    Observaciones = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Comuna",
                        columns: x => new { x.RegionCodigo, x.CiudadCodigo, x.ComunaCodigo },
                        principalTable: "Comuna",
                        principalColumns: new[] { "RegionCodigo", "CiudadCodigo", "Codigo" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Sexo",
                        column: x => x.SexoCodigo,
                        principalTable: "Sexo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_RegionCodigo_CiudadCodigo_ComunaCodigo",
                table: "Persona",
                columns: new[] { "RegionCodigo", "CiudadCodigo", "ComunaCodigo" });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_SexoCodigo",
                table: "Persona",
                column: "SexoCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Comuna");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
