using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "appUsers");

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 16, 22, 23, 25, 657, DateTimeKind.Local).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 16, 22, 23, 25, 657, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 16, 22, 23, 25, 657, DateTimeKind.Local).AddTicks(6109));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "appUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "appUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "appUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "appUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "appUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "appUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "appUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { 0, "d8cd15e9-f861-4773-ae67-43e7f59c76b9", false, false, null, null, null, null, null, false, "b268b080-3984-4066-9976-c5855c7bd0e8", false });

            migrationBuilder.UpdateData(
                table: "appUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { 0, "5452f81a-100e-4df7-8e3e-c69c8ef31d91", false, false, null, null, null, null, null, false, "704b1b17-e05f-4324-a8f2-3ca67777e512", false });

            migrationBuilder.UpdateData(
                table: "appUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { 0, "b8351847-2a84-4a89-b956-f8c401889424", false, false, null, null, null, null, null, false, "e54ecd13-3772-4cc7-874e-078f1b6ffe20", false });

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 15, 0, 3, 33, 698, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 15, 0, 3, 33, 698, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 15, 0, 3, 33, 698, DateTimeKind.Local).AddTicks(3021));
        }
    }
}
