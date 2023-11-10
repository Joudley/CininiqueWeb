using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DossierPatient",
                columns: table => new
                {
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Sexe = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    Adresse = table.Column<string>(type: "TEXT", nullable: true),
                    ConsultationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierPatient", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Medecin",
                columns: table => new
                {
                    MedecinId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Sexe = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Specialite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecin", x => x.MedecinId);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    ConsultationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedecinId = table.Column<int>(type: "INTEGER", nullable: false),
                    CodePatient = table.Column<string>(type: "TEXT", nullable: true),
                    Poids = table.Column<double>(type: "REAL", nullable: false),
                    Hauteur = table.Column<int>(type: "INTEGER", nullable: false),
                    Diagnostique = table.Column<string>(type: "TEXT", nullable: true),
                    ConsultationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.ConsultationId);
                    table.ForeignKey(
                        name: "FK_Consultation_Medecin_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecin",
                        principalColumn: "MedecinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultationDossierPatient",
                columns: table => new
                {
                    ConsultationId = table.Column<int>(type: "INTEGER", nullable: false),
                    DossierPatientCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationDossierPatient", x => new { x.ConsultationId, x.DossierPatientCode });
                    table.ForeignKey(
                        name: "FK_ConsultationDossierPatient_Consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultation",
                        principalColumn: "ConsultationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultationDossierPatient_DossierPatient_DossierPatientCode",
                        column: x => x.DossierPatientCode,
                        principalTable: "DossierPatient",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConsultationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Prescrire = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescription_Consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultation",
                        principalColumn: "ConsultationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_MedecinId",
                table: "Consultation",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationDossierPatient_DossierPatientCode",
                table: "ConsultationDossierPatient",
                column: "DossierPatientCode");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ConsultationId",
                table: "Prescription",
                column: "ConsultationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultationDossierPatient");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "DossierPatient");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Medecin");
        }
    }
}
