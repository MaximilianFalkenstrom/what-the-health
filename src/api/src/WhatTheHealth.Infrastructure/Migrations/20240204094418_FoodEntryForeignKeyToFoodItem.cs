using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatTheHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FoodEntryForeignKeyToFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodEntryId",
                table: "FoodEntries",
                newName: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntries_FoodItemId",
                table: "FoodEntries",
                column: "FoodItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodEntries_FoodItems_FoodItemId",
                table: "FoodEntries",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodEntries_FoodItems_FoodItemId",
                table: "FoodEntries");

            migrationBuilder.DropIndex(
                name: "IX_FoodEntries_FoodItemId",
                table: "FoodEntries");

            migrationBuilder.RenameColumn(
                name: "FoodItemId",
                table: "FoodEntries",
                newName: "FoodEntryId");
        }
    }
}
