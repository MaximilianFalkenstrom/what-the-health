using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatTheHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSettings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserSettings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserSettings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings",
                column: "Id");
        }
    }
}
