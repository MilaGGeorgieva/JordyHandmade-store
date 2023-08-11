using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordyHandmade.Data.Migrations
{
    public partial class SoftDeletePropDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsObsolete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 11, 12, 25, 56, 372, DateTimeKind.Utc).AddTicks(6032),
                comment: "Date product was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 11, 10, 48, 9, 49, DateTimeKind.Utc).AddTicks(7189),
                oldComment: "Date product was created");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("a216e810-d619-4458-ba85-7a4faac5322d"), 2, "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!", "/Images/ProductImages/SunnyBackpack.jpg", "Bright sunny backpack", 25.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("a4c109d3-f043-4f1a-88e5-52aed878bfbc"), 1, "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!", "/Images/ProductImages/HeartPillows.jpg", "Heart pillow", 20.00m, 6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("fc2250de-8435-44b2-bf29-4e38c0c1c786"), 2, "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ", "/Images/ProductImages/DenimBagSet.jpg", "Girlish style denim bag set", 29.00m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a216e810-d619-4458-ba85-7a4faac5322d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a4c109d3-f043-4f1a-88e5-52aed878bfbc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc2250de-8435-44b2-bf29-4e38c0c1c786"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsObsolete",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 11, 10, 48, 9, 49, DateTimeKind.Utc).AddTicks(7189),
                comment: "Date product was created",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 11, 12, 25, 56, 372, DateTimeKind.Utc).AddTicks(6032),
                oldComment: "Date product was created");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsObsolete", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("01e29ca1-a601-48fe-83b9-5d1eef994fd3"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweet heart-like pillow for decoration. Made with pure cotton cover and decorated with beads. Ideal for Valentine's gifts!", "/Images/ProductImages/HeartPillows.jpg", false, "Heart pillow", 20.00m, 6 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsObsolete", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("08a87a86-b3d3-4844-ac38-4866d4ebcfcd"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A small jeans bag with hand embroidered kittens. Lined with bright green linen, 5 pockets, snap buttons, has a matching mobile phone case with velcro bands and a small coin purse with zipper. ", "/Images/ProductImages/DenimBagSet.jpg", false, "Girlish style denim bag set", 29.00m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsObsolete", "Name", "Price", "QuantityInStock" },
                values: new object[] { new Guid("8fda1480-97fb-4028-b8f3-a9c2841925be"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crochet backpack/sack in sunny/summer pattern. Lined with 100% cotton inside in yellow color with polka dots, has 2 pockets - suitable for mobilephones. Ideal for sea beach or city life!", "/Images/ProductImages/SunnyBackpack.jpg", false, "Bright sunny backpack", 25.00m, 1 });
        }
    }
}
