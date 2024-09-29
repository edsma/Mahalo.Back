using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahalo.Back.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateCathe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Psychologists_PsychologistId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_State_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationSchedulingResources_NotificationSechedulings_NotificationsSchedulingId",
                table: "NotificationSchedulingResources");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationSchedulingResources_Resources_ResourceId",
                table: "NotificationSchedulingResources");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationSechedulings_Users_UserId",
                table: "NotificationSechedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Countries_CountryId",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_Terapy_Cities_CityId",
                table: "Terapy");

            migrationBuilder.DropForeignKey(
                name: "FK_Terapy_Psychologists_PsychologistId",
                table: "Terapy");

            migrationBuilder.DropForeignKey(
                name: "FK_Terapy_Users_UserId",
                table: "Terapy");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_PsychologistId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terapy",
                table: "Terapy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationSechedulings",
                table: "NotificationSechedulings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationSchedulingResources",
                table: "NotificationSchedulingResources");

            migrationBuilder.DropColumn(
                name: "PsychologistId",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Terapy",
                newName: "Terapies");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "NotificationSechedulings",
                newName: "NotificationsScheduling");

            migrationBuilder.RenameTable(
                name: "NotificationSchedulingResources",
                newName: "NotificationsSchedulingResources");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Resources",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Terapies",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Terapy_UserId",
                table: "Terapies",
                newName: "IX_Terapies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Terapy_PsychologistId",
                table: "Terapies",
                newName: "IX_Terapies_PsychologistId");

            migrationBuilder.RenameIndex(
                name: "IX_Terapy_CityId",
                table: "Terapies",
                newName: "IX_Terapies_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_State_CountryId",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationSechedulings_UserId",
                table: "NotificationsScheduling",
                newName: "IX_NotificationsScheduling_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationSchedulingResources_ResourceId",
                table: "NotificationsSchedulingResources",
                newName: "IX_NotificationsSchedulingResources_ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationSchedulingResources_NotificationsSchedulingId",
                table: "NotificationsSchedulingResources",
                newName: "IX_NotificationsSchedulingResources_NotificationsSchedulingId");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "ResourcesDisorder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisorderId",
                table: "ResourcesDisorder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Psychologists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "NotificationsHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "DocumentTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PsychologistId",
                table: "Terapies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Terapies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "NotificationsSchedulingResources",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terapies",
                table: "Terapies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationsScheduling",
                table: "NotificationsScheduling",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationsSchedulingResources",
                table: "NotificationsSchedulingResources",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourcesDisorder_Id",
                table: "ResourcesDisorder",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Id",
                table: "Resources",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Psychologists_CityId",
                table: "Psychologists",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Psychologists_Id",
                table: "Psychologists",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsHistory_Id",
                table: "NotificationsHistory",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_Id",
                table: "DocumentTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disorders_Id",
                table: "Disorders",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Id",
                table: "Countries",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Id",
                table: "Cities",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terapies_Id",
                table: "Terapies",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_Id",
                table: "States",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsScheduling_Id",
                table: "NotificationsScheduling",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsSchedulingResources_Id",
                table: "NotificationsSchedulingResources",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationsScheduling_Users_UserId",
                table: "NotificationsScheduling",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationsSchedulingResources_NotificationsScheduling_NotificationsSchedulingId",
                table: "NotificationsSchedulingResources",
                column: "NotificationsSchedulingId",
                principalTable: "NotificationsScheduling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationsSchedulingResources_Resources_ResourceId",
                table: "NotificationsSchedulingResources",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Psychologists_Cities_CityId",
                table: "Psychologists",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terapies_Cities_CityId",
                table: "Terapies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terapies_Psychologists_PsychologistId",
                table: "Terapies",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terapies_Users_UserId",
                table: "Terapies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationsScheduling_Users_UserId",
                table: "NotificationsScheduling");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationsSchedulingResources_NotificationsScheduling_NotificationsSchedulingId",
                table: "NotificationsSchedulingResources");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationsSchedulingResources_Resources_ResourceId",
                table: "NotificationsSchedulingResources");

            migrationBuilder.DropForeignKey(
                name: "FK_Psychologists_Cities_CityId",
                table: "Psychologists");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_Terapies_Cities_CityId",
                table: "Terapies");

            migrationBuilder.DropForeignKey(
                name: "FK_Terapies_Psychologists_PsychologistId",
                table: "Terapies");

            migrationBuilder.DropForeignKey(
                name: "FK_Terapies_Users_UserId",
                table: "Terapies");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ResourcesDisorder_Id",
                table: "ResourcesDisorder");

            migrationBuilder.DropIndex(
                name: "IX_Resources_Id",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Psychologists_CityId",
                table: "Psychologists");

            migrationBuilder.DropIndex(
                name: "IX_Psychologists_Id",
                table: "Psychologists");

            migrationBuilder.DropIndex(
                name: "IX_NotificationsHistory_Id",
                table: "NotificationsHistory");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_Id",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Disorders_Id",
                table: "Disorders");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Id",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Id",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terapies",
                table: "Terapies");

            migrationBuilder.DropIndex(
                name: "IX_Terapies_Id",
                table: "Terapies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_Id",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationsSchedulingResources",
                table: "NotificationsSchedulingResources");

            migrationBuilder.DropIndex(
                name: "IX_NotificationsSchedulingResources_Id",
                table: "NotificationsSchedulingResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationsScheduling",
                table: "NotificationsScheduling");

            migrationBuilder.DropIndex(
                name: "IX_NotificationsScheduling_Id",
                table: "NotificationsScheduling");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "DocumentTypes");

            migrationBuilder.RenameTable(
                name: "Terapies",
                newName: "Terapy");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "NotificationsSchedulingResources",
                newName: "NotificationSchedulingResources");

            migrationBuilder.RenameTable(
                name: "NotificationsScheduling",
                newName: "NotificationSechedulings");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Resources",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Terapy",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Terapies_UserId",
                table: "Terapy",
                newName: "IX_Terapy_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Terapies_PsychologistId",
                table: "Terapy",
                newName: "IX_Terapy_PsychologistId");

            migrationBuilder.RenameIndex(
                name: "IX_Terapies_CityId",
                table: "Terapy",
                newName: "IX_Terapy_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "State",
                newName: "IX_State_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationsSchedulingResources_ResourceId",
                table: "NotificationSchedulingResources",
                newName: "IX_NotificationSchedulingResources_ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationsSchedulingResources_NotificationsSchedulingId",
                table: "NotificationSchedulingResources",
                newName: "IX_NotificationSchedulingResources_NotificationsSchedulingId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationsScheduling_UserId",
                table: "NotificationSechedulings",
                newName: "IX_NotificationSechedulings_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "ResourcesDisorder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DisorderId",
                table: "ResourcesDisorder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "NotificationsHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PsychologistId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PsychologistId",
                table: "Terapy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Terapy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResourceId",
                table: "NotificationSchedulingResources",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terapy",
                table: "Terapy",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationSchedulingResources",
                table: "NotificationSchedulingResources",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationSechedulings",
                table: "NotificationSechedulings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_PsychologistId",
                table: "Cities",
                column: "PsychologistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Psychologists_PsychologistId",
                table: "Cities",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_State_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationSchedulingResources_NotificationSechedulings_NotificationsSchedulingId",
                table: "NotificationSchedulingResources",
                column: "NotificationsSchedulingId",
                principalTable: "NotificationSechedulings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationSchedulingResources_Resources_ResourceId",
                table: "NotificationSchedulingResources",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationSechedulings_Users_UserId",
                table: "NotificationSechedulings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Countries_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terapy_Cities_CityId",
                table: "Terapy",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terapy_Psychologists_PsychologistId",
                table: "Terapy",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terapy_Users_UserId",
                table: "Terapy",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
