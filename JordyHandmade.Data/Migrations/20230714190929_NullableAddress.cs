using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordyHandmade.Data.Migrations
{
    public partial class NullableAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0369b41e-1ad1-466b-9de9-cac4d61477dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7025a6a2-ef69-45c8-8cae-1fb61b23667f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f020a5aa-7fc3-4ff4-ba52-0f8d934fc296"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 14, 19, 9, 29, 135, DateTimeKind.Utc).AddTicks(2132),
                comment: "Date product was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 10, 19, 34, 7, 983, DateTimeKind.Utc).AddTicks(4684),
                oldComment: "Date product was created");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("6f746f35-0990-4ff9-995a-d702ece65628"), 2, "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ", "/Images/ProductImages/DenimBagSet.jpg", "Girlish style denim bag set", 29.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("92c66c88-e459-4996-aff5-31c7325358d3"), 2, "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!", "/Images/ProductImages/SunnyBackpack.jpg", "Bright sunny backpack", 25.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("f186342b-a61a-4375-9096-a193dd24cd3a"), 1, "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!", "/Images/ProductImages/HeartPillows.jpg", "Heart pillow", 20.00m, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f746f35-0990-4ff9-995a-d702ece65628"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("92c66c88-e459-4996-aff5-31c7325358d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f186342b-a61a-4375-9096-a193dd24cd3a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 10, 19, 34, 7, 983, DateTimeKind.Utc).AddTicks(4684),
                comment: "Date product was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 14, 19, 9, 29, 135, DateTimeKind.Utc).AddTicks(2132),
                oldComment: "Date product was created");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("0369b41e-1ad1-466b-9de9-cac4d61477dd"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ", "/Images/ProductImages/DenimBagSet.jpg", "Girlish style denim bag set", 29.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("7025a6a2-ef69-45c8-8cae-1fb61b23667f"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!", "/Images/ProductImages/HeartPillows.jpg", "Heart pillow", 20.00m, 6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("f020a5aa-7fc3-4ff4-ba52-0f8d934fc296"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!", "/Images/ProductImages/SunnyBackpack.jpg", "Bright sunny backpack", 25.00m, 1 });
        }
    }
}
