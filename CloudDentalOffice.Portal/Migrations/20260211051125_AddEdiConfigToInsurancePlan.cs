using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudDentalOffice.Portal.Migrations
{
    /// <inheritdoc />
    public partial class AddEdiConfigToInsurancePlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiAuthType",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApiEndpoint",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApiKeyEncrypted",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EdiEnabled",
                table: "InsurancePlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EdiSubmissionType",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SftpHost",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SftpPasswordEncrypted",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SftpPort",
                table: "InsurancePlans",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SftpRemotePath",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SftpSshKeyEncrypted",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SftpUseSshKey",
                table: "InsurancePlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SftpUsername",
                table: "InsurancePlans",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "InsurancePlans",
                keyColumn: "InsurancePlanId",
                keyValue: 1,
                columns: new[] { "ApiAuthType", "ApiEndpoint", "ApiKeyEncrypted", "EdiEnabled", "EdiSubmissionType", "SftpHost", "SftpPasswordEncrypted", "SftpPort", "SftpRemotePath", "SftpSshKeyEncrypted", "SftpUseSshKey", "SftpUsername" },
                values: new object[] { null, null, null, false, null, null, null, null, null, null, false, null });

            migrationBuilder.UpdateData(
                table: "InsurancePlans",
                keyColumn: "InsurancePlanId",
                keyValue: 2,
                columns: new[] { "ApiAuthType", "ApiEndpoint", "ApiKeyEncrypted", "EdiEnabled", "EdiSubmissionType", "SftpHost", "SftpPasswordEncrypted", "SftpPort", "SftpRemotePath", "SftpSshKeyEncrypted", "SftpUseSshKey", "SftpUsername" },
                values: new object[] { null, null, null, false, null, null, null, null, null, null, false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiAuthType",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "ApiEndpoint",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "ApiKeyEncrypted",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "EdiEnabled",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "EdiSubmissionType",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "SftpHost",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "SftpPasswordEncrypted",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "SftpPort",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "SftpRemotePath",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "SftpSshKeyEncrypted",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "SftpUseSshKey",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "SftpUsername",
                table: "InsurancePlans");
        }
    }
}
