using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRowsToCategoriesTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Categories Values('Category 1')");
            migrationBuilder.Sql("Insert Into Categories Values('Category 2')");
            migrationBuilder.Sql("Insert Into Categories Values('Category 3')");
            migrationBuilder.Sql("Insert Into Categories Values('Category 4')");
            migrationBuilder.Sql("Insert Into Categories Values('Category 5')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
