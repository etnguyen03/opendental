using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudDentalOffice.Portal.Migrations
{
    /// <inheritdoc />
    public partial class AddProceduresAndClinicalNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicalNotes",
                columns: table => new
                {
                    ClinicalNoteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false, defaultValue: "dev"),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProviderId = table.Column<int>(type: "INTEGER", nullable: true),
                    NoteDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoteType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NoteText = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsConfidential = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalNotes", x => x.ClinicalNoteId);
                    table.ForeignKey(
                        name: "FK_ClinicalNotes_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicalNotes_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false, defaultValue: "dev"),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProviderId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppointmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    CDTCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ToothNumber = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    Surface = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChargeAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    InsuranceEstimate = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PatientPortion = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.ProcedureId);
                    table.ForeignKey(
                        name: "FK_Procedures_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Procedures_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 58, 9, 610, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalNotes_NoteDate",
                table: "ClinicalNotes",
                column: "NoteDate");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalNotes_NoteType",
                table: "ClinicalNotes",
                column: "NoteType");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalNotes_PatientId",
                table: "ClinicalNotes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalNotes_ProviderId",
                table: "ClinicalNotes",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalNotes_TenantId",
                table: "ClinicalNotes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_AppointmentId",
                table: "Procedures",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_CDTCode",
                table: "Procedures",
                column: "CDTCode");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_PatientId",
                table: "Procedures",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ProviderId",
                table: "Procedures",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ServiceDate",
                table: "Procedures",
                column: "ServiceDate");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_TenantId",
                table: "Procedures",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicalNotes");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "ProcedureCodes",
                keyColumn: "ProcedureCodeId",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 13, 9, 25, 47, 538, DateTimeKind.Utc).AddTicks(8400));
        }
    }
}
