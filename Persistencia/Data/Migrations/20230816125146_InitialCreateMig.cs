using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    IdGeneroFk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreGenero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.IdGeneroFk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    IdPais = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.IdPais);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    IdSalon = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSalon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.IdSalon);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPersona",
                columns: table => new
                {
                    IdTipoPersona = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionTipoPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersona", x => x.IdTipoPersona);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    IdDep = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreDep = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFk = table.Column<string>(type: "varchar(3)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.IdDep);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_IdPaisFk",
                        column: x => x.IdPaisFk,
                        principalTable: "Pais",
                        principalColumn: "IdPais");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    IdCiudad = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCiudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepFk = table.Column<string>(type: "varchar(3)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.IdCiudad);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento_IdDepFk",
                        column: x => x.IdDepFk,
                        principalTable: "Departamento",
                        principalColumn: "IdDep");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdGeneroFk = table.Column<int>(type: "int", nullable: false),
                    IdCiudadFk = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPerFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Persona_Ciudad_IdCiudadFk",
                        column: x => x.IdCiudadFk,
                        principalTable: "Ciudad",
                        principalColumn: "IdCiudad");
                    table.ForeignKey(
                        name: "FK_Persona_Genero_IdGeneroFk",
                        column: x => x.IdGeneroFk,
                        principalTable: "Genero",
                        principalColumn: "IdGeneroFk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_TipoPersona_IdTipoPerFk",
                        column: x => x.IdTipoPerFk,
                        principalTable: "TipoPersona",
                        principalColumn: "IdTipoPersona",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonaFK = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonaIdPersona = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdSalonFk = table.Column<int>(type: "int", nullable: false),
                    SalonIdSalon = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.IdMatricula);
                    table.ForeignKey(
                        name: "FK_Matricula_Persona_PersonaIdPersona",
                        column: x => x.PersonaIdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona");
                    table.ForeignKey(
                        name: "FK_Matricula_Salon_SalonIdSalon",
                        column: x => x.SalonIdSalon,
                        principalTable: "Salon",
                        principalColumn: "IdSalon");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trainersalon",
                columns: table => new
                {
                    IdPerTrainerFk = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdSalonFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainersalon", x => new { x.IdSalonFk, x.IdPerTrainerFk });
                    table.ForeignKey(
                        name: "FK_Trainersalon_Persona_IdPerTrainerFk",
                        column: x => x.IdPerTrainerFk,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainersalon_Salon_IdSalonFk",
                        column: x => x.IdSalonFk,
                        principalTable: "Salon",
                        principalColumn: "IdSalon",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_IdDepFk",
                table: "Ciudad",
                column: "IdDepFk");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdPaisFk",
                table: "Departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_PersonaIdPersona",
                table: "Matricula",
                column: "PersonaIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_SalonIdSalon",
                table: "Matricula",
                column: "SalonIdSalon");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdCiudadFk",
                table: "Persona",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdGeneroFk",
                table: "Persona",
                column: "IdGeneroFk");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdTipoPerFk",
                table: "Persona",
                column: "IdTipoPerFk");

            migrationBuilder.CreateIndex(
                name: "IX_Trainersalon_IdPerTrainerFk",
                table: "Trainersalon",
                column: "IdPerTrainerFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Trainersalon");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "TipoPersona");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
