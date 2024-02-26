using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatTheHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MealType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MealTypeId",
                table: "FoodEntries",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MealType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntries_MealTypeId",
                table: "FoodEntries",
                column: "MealTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodEntries_MealType_MealTypeId",
                table: "FoodEntries",
                column: "MealTypeId",
                principalTable: "MealType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodEntries_MealType_MealTypeId",
                table: "FoodEntries");

            migrationBuilder.DropTable(
                name: "MealType");

            migrationBuilder.DropIndex(
                name: "IX_FoodEntries_MealTypeId",
                table: "FoodEntries");

            migrationBuilder.DropColumn(
                name: "MealTypeId",
                table: "FoodEntries");
        }
    }
}
