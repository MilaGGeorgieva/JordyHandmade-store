using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordyHandmade.Data.Migrations
{
    public partial class AddSoftDeleteProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 11, 10, 48, 9, 49, DateTimeKind.Utc).AddTicks(7189),
                comment: "Date product was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 23, 15, 20, 5, 217, DateTimeKind.Utc).AddTicks(8807),
                oldComment: "Date product was created");

            migrationBuilder.AddColumn<bool>(
                name: "IsObsolete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "PartsInProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsObsolete", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("01e29ca1-a601-48fe-83b9-5d1eef994fd3"), 1, "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!", "/Images/ProductImages/HeartPillows.jpg", false, "Heart pillow", 20.00m, 6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsObsolete", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("08a87a86-b3d3-4844-ac38-4866d4ebcfcd"), 2, "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ", "/Images/ProductImages/DenimBagSet.jpg", false, "Girlish style denim bag set", 29.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsObsolete", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("8fda1480-97fb-4028-b8f3-a9c2841925be"), 2, "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!", "/Images/ProductImages/SunnyBackpack.jpg", false, "Bright sunny backpack", 25.00m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("01e29ca1-a601-48fe-83b9-5d1eef994fd3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08a87a86-b3d3-4844-ac38-4866d4ebcfcd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8fda1480-97fb-4028-b8f3-a9c2841925be"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsObsolete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "PartsInProducts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 15, 20, 5, 217, DateTimeKind.Utc).AddTicks(8807),
                comment: "Date product was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 11, 10, 48, 9, 49, DateTimeKind.Utc).AddTicks(7189),
                oldComment: "Date product was created");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("2551af74-95d2-4e0b-84be-5e5c61238623"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!", "/Images/ProductImages/HeartPillows.jpg", "Heart pillow", 20.00m, 6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("28e7de7c-fcda-4e20-a609-a9022e2dc1e0"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ", "/Images/ProductImages/DenimBagSet.jpg", "Girlish style denim bag set", 29.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("e30834e3-56a8-4b67-8e6a-044a49cb466c"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!", "/Images/ProductImages/SunnyBackpack.jpg", "Bright sunny backpack", 25.00m, 1 });
        }
    }
}
