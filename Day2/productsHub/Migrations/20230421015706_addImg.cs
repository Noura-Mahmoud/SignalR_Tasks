using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace productsHub.Migrations
{
    /// <inheritdoc />
    public partial class addImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pexels.com%2Fsearch%2Fproduct%2F&psig=AOvVaw2QSFv-i0iAoFK4LzV2s6I9&ust=1682128349013000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCJiiscjuuf4CFQAAAAAdAAAAABAJ");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fproduct&psig=AOvVaw2QSFv-i0iAoFK4LzV2s6I9&ust=1682128349013000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCJiiscjuuf4CFQAAAAAdAAAAABAE");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fproduct&psig=AOvVaw2QSFv-i0iAoFK4LzV2s6I9&ust=1682128349013000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCJiiscjuuf4CFQAAAAAdAAAAABAO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");
        }
    }
}
