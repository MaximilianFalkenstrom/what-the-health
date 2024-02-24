using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatTheHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SaveUserDetailsV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Carbs",
                table: "UserDetails",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "UserDetails",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "UserDetails",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "UserDetails");
        }
    }
}
