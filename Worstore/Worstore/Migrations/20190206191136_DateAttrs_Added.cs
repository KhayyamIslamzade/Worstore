using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Worstore.Migrations
{
    public partial class DateAttrs_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedTime",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "AddedTime",
                table: "Meaning");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Word",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Word",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Word",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Word",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SpokenLanguage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "SpokenLanguage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "SpokenLanguage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SpokenLanguage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Meaning",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Meaning",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Meaning",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Meaning",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Group",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Group",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Group",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Group",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SpokenLanguage");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "SpokenLanguage");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "SpokenLanguage");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SpokenLanguage");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Meaning");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Meaning");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Meaning");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Meaning");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Group");

            migrationBuilder.AddColumn<string>(
                name: "AddedTime",
                table: "Word",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedTime",
                table: "Meaning",
                maxLength: 30,
                nullable: true);
        }
    }
}
