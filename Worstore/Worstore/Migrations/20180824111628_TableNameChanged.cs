using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Worstore.Migrations
{
    public partial class TableNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_SpeekingLanguage_FkLanguage",
                table: "Word");

            migrationBuilder.DropTable(
                name: "SpeekingLanguage");

            migrationBuilder.CreateTable(
                name: "SpokenLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    FlagUrl = table.Column<string>(nullable: true),
                    Label = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguage", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Word_SpokenLanguage_FkLanguage",
                table: "Word",
                column: "FkLanguage",
                principalTable: "SpokenLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_SpokenLanguage_FkLanguage",
                table: "Word");

            migrationBuilder.DropTable(
                name: "SpokenLanguage");

            migrationBuilder.CreateTable(
                name: "SpeekingLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    FlagUrl = table.Column<string>(nullable: true),
                    Label = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeekingLanguage", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Word_SpeekingLanguage_FkLanguage",
                table: "Word",
                column: "FkLanguage",
                principalTable: "SpeekingLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
