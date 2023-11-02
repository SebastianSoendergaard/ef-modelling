using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "3layer.user_groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_3layer.user_groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "3layer.user_registrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserRegistrationStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_3layer.user_registrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "3layer.users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_3layer.users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "3layer.user_group_members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MemberId = table.Column<string>(type: "TEXT", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_3layer.user_group_members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_3layer.user_group_members_3layer.user_groups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "3layer.user_groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_3layer.user_group_members_UserGroupId",
                table: "3layer.user_group_members",
                column: "UserGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "3layer.user_group_members");

            migrationBuilder.DropTable(
                name: "3layer.user_registrations");

            migrationBuilder.DropTable(
                name: "3layer.users");

            migrationBuilder.DropTable(
                name: "3layer.user_groups");
        }
    }
}
