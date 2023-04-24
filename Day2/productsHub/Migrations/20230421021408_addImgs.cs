using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace productsHub.Migrations
{
    /// <inheritdoc />
    public partial class addImgs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cHJvZHVjdHxlbnwwfHwwfHw%3D&w=1000&q=80");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pexels.com%2Fsearch%2Fproduct%2F&psig=AOvVaw2QSFv-i0iAoFK4LzV2s6I9&ust=1682128349013000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCJiiscjuuf4CFQAAAAAdAAAAABAJ");
        }
    }
}
