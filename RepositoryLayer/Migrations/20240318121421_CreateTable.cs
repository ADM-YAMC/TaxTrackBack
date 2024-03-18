using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Erros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetodoBase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Erros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoContribuyentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContribuyentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contribuyentesFiscales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoContribuyente = table.Column<int>(type: "int", nullable: false),
                    RncCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contribuyentesFiscales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contribuyentesFiscales_TipoContribuyentes_IdTipoContribuyente",
                        column: x => x.IdTipoContribuyente,
                        principalTable: "TipoContribuyentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comprobanteFiscales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RncCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NCF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Itbis18 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContribuyenteFiscalId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comprobanteFiscales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comprobanteFiscales_contribuyentesFiscales_ContribuyenteFiscalId",
                        column: x => x.ContribuyenteFiscalId,
                        principalTable: "contribuyentesFiscales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_comprobanteFiscales_ContribuyenteFiscalId",
                table: "comprobanteFiscales",
                column: "ContribuyenteFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_contribuyentesFiscales_IdTipoContribuyente",
                table: "contribuyentesFiscales",
                column: "IdTipoContribuyente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comprobanteFiscales");

            migrationBuilder.DropTable(
                name: "Erros");

            migrationBuilder.DropTable(
                name: "contribuyentesFiscales");

            migrationBuilder.DropTable(
                name: "TipoContribuyentes");
        }
    }
}
