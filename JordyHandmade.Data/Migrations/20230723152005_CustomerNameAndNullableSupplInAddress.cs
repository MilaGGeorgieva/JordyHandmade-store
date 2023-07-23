using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordyHandmade.Data.Migrations
{
    public partial class CustomerNameAndNullableSupplInAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("21ebbe22-d566-4466-8037-e34d34233965"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ae147215-af0b-4ebc-be80-859616d09a36"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba745eba-864c-48df-bfd7-96329d565dbf"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 15, 20, 5, 217, DateTimeKind.Utc).AddTicks(8807),
                comment: "Date product was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 9, 44, 37, 60, DateTimeKind.Utc).AddTicks(1046),
                oldComment: "Date product was created");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "AspNetUsers",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true,
                comment: "Customer First and Last name");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("2551af74-95d2-4e0b-84be-5e5c61238623"), 1, "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!", "/Images/ProductImages/HeartPillows.jpg", "Heart pillow", 20.00m, 6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("28e7de7c-fcda-4e20-a609-a9022e2dc1e0"), 2, "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ", "/Images/ProductImages/DenimBagSet.jpg", "Girlish style denim bag set", 29.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("e30834e3-56a8-4b67-8e6a-044a49cb466c"), 2, "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!", "/Images/ProductImages/SunnyBackpack.jpg", "Bright sunny backpack", 25.00m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2551af74-95d2-4e0b-84be-5e5c61238623"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("28e7de7c-fcda-4e20-a609-a9022e2dc1e0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e30834e3-56a8-4b67-8e6a-044a49cb466c"));

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 9, 44, 37, 60, DateTimeKind.Utc).AddTicks(1046),
                comment: "Date product was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 23, 15, 20, 5, 217, DateTimeKind.Utc).AddTicks(8807),
                oldComment: "Date product was created");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("21ebbe22-d566-4466-8037-e34d34233965"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!", "/Images/ProductImages/HeartPillows.jpg", "Heart pillow", 20.00m, 6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("ae147215-af0b-4ebc-be80-859616d09a36"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ", "/Images/ProductImages/DenimBagSet.jpg", "Girlish style denim bag set", 29.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("ba745eba-864c-48df-bfd7-96329d565dbf"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!", "/Images/ProductImages/SunnyBackpack.jpg", "Bright sunny backpack", 25.00m, 1 });
        }
    }
}
