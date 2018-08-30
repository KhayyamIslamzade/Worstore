using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Worstore.Migrations
{
    public partial class group_table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_SpokenLanguage_FkLanguage",
                table: "Word");

            migrationBuilder.DropForeignKey(
                name: "FK_Word_AspNetUsers_FkUser",
                table: "Word");

            migrationBuilder.DropIndex(
                name: "IX_Word_FkUser",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "FkUser",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Word");

            migrationBuilder.RenameColumn(
                name: "FkLanguage",
                table: "Word",
                newName: "FkGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Word_FkLanguage",
                table: "Word",
                newName: "IX_Word_FkGroup");

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FkLanguage = table.Column<int>(nullable: false),
                    FkUser = table.Column<string>(nullable: false),
                    Label = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_SpokenLanguage_FkLanguage",
                        column: x => x.FkLanguage,
                        principalTable: "SpokenLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_AspNetUsers_FkUser",
                        column: x => x.FkUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_FkLanguage",
                table: "Group",
                column: "FkLanguage");

            migrationBuilder.CreateIndex(
                name: "IX_Group_FkUser",
                table: "Group",
                column: "FkUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Group_FkGroup",
                table: "Word",
                column: "FkGroup",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_Group_FkGroup",
                table: "Word");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.RenameColumn(
                name: "FkGroup",
                table: "Word",
                newName: "FkLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_Word_FkGroup",
                table: "Word",
                newName: "IX_Word_FkLanguage");

            migrationBuilder.AddColumn<string>(
                name: "FkUser",
                table: "Word",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Word",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Word_FkUser",
                table: "Word",
                column: "FkUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Word_SpokenLanguage_FkLanguage",
                table: "Word",
                column: "FkLanguage",
                principalTable: "SpokenLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Word_AspNetUsers_FkUser",
                table: "Word",
                column: "FkUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
