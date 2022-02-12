using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Data.Migrations
{
    public partial class DeparmentcontactRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DepartmentId",
                table: "Contacts",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Departments_DepartmentId",
                table: "Contacts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Departments_DepartmentId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_DepartmentId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Contacts");
        }
    }
}
