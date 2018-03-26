using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Auth.API.Migrations
{
    public partial class addedpassworddigestandsalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password_digest",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password_salt",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_digest",
                table: "User");

            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "User");
        }
    }
}
