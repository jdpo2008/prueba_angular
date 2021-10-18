using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AP_Examen.Persistencia.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AP_Perez_Jose_Alumno",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Sexo = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioEdicion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaEdicion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AP_Perez_Jose_Alumno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AP_Perez_Jose_Curso",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Obligatoriedad = table.Column<bool>(type: "bit", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioEdicion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaEdicion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AP_Perez_Jose_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AP_Perez_Jose_CursosAlumno",
                schema: "dbo",
                columns: table => new
                {
                    AlumnosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CursosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AP_Perez_Jose_CursosAlumno", x => new { x.AlumnosId, x.CursosId });
                    table.ForeignKey(
                        name: "FK_AP_Perez_Jose_CursosAlumno_AP_Perez_Jose_Alumno_AlumnosId",
                        column: x => x.AlumnosId,
                        principalSchema: "dbo",
                        principalTable: "AP_Perez_Jose_Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AP_Perez_Jose_CursosAlumno_AP_Perez_Jose_Curso_CursosId",
                        column: x => x.CursosId,
                        principalSchema: "dbo",
                        principalTable: "AP_Perez_Jose_Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AP_Perez_Jose_NotasAlumno",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlumnoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Practicas = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Parcial = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Final = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    PromedioPracticas = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    PromedioParcial = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    PromedioFinal = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioEdicion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaEdicion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AP_Perez_Jose_NotasAlumno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AP_Perez_Jose_NotasAlumno_AP_Perez_Jose_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalSchema: "dbo",
                        principalTable: "AP_Perez_Jose_Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AP_Perez_Jose_NotasAlumno_AP_Perez_Jose_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "dbo",
                        principalTable: "AP_Perez_Jose_Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AP_Perez_Jose_CursosAlumno_CursosId",
                schema: "dbo",
                table: "AP_Perez_Jose_CursosAlumno",
                column: "CursosId");

            migrationBuilder.CreateIndex(
                name: "IX_AP_Perez_Jose_NotasAlumno_AlumnoId",
                schema: "dbo",
                table: "AP_Perez_Jose_NotasAlumno",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_AP_Perez_Jose_NotasAlumno_CursoId",
                schema: "dbo",
                table: "AP_Perez_Jose_NotasAlumno",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AP_Perez_Jose_CursosAlumno",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AP_Perez_Jose_NotasAlumno",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AP_Perez_Jose_Alumno",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AP_Perez_Jose_Curso",
                schema: "dbo");
        }
    }
}
