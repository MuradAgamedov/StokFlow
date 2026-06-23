using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModernWMC.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAboutDataFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhoAreWeListThird_text_title",
                table: "Abouts",
                newName: "WhoAreWeListThirdTextTitle");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListThird_text",
                table: "Abouts",
                newName: "WhoAreWeListThirdText");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListSecond_text_title",
                table: "Abouts",
                newName: "WhoAreWeListSecondTextTitle");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListSecond_text",
                table: "Abouts",
                newName: "WhoAreWeListSecondText");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListFirst_text_title",
                table: "Abouts",
                newName: "WhoAreWeListFirstTextTitle");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListFirst_text",
                table: "Abouts",
                newName: "WhoAreWeListFirstText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhoAreWeListThirdTextTitle",
                table: "Abouts",
                newName: "WhoAreWeListThird_text_title");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListThirdText",
                table: "Abouts",
                newName: "WhoAreWeListThird_text");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListSecondTextTitle",
                table: "Abouts",
                newName: "WhoAreWeListSecond_text_title");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListSecondText",
                table: "Abouts",
                newName: "WhoAreWeListSecond_text");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListFirstTextTitle",
                table: "Abouts",
                newName: "WhoAreWeListFirst_text_title");

            migrationBuilder.RenameColumn(
                name: "WhoAreWeListFirstText",
                table: "Abouts",
                newName: "WhoAreWeListFirst_text");
        }
    }
}
