using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuDemo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/5/55/Adana_kebab.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.diyetkolik.com/site_media/media/foodrecipe_images/ufra-kabap.png");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://cevatusta.com.tr/wp-content/uploads/2020/11/Urfa-Lahmacun.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://turkishfoodie.com/wp-content/uploads/2019/01/Pide.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://i.lezzet.com.tr/images-xxlarge-secondary/manti-nasil-pisirilir-9853d099-517c-4e89-be1c-960b703dcb8e.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://www.unileverfoodsolutions.com.tr/dam/global-ufs/mcos/TURKEY/calcmenu/recipes/TR-recipes/general/k%C3%B6fte-izgara/main-header.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.nefisyemektarifleri.com/2021/08/25/adana-kebap-tarifi-8.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://i.nefisyemektarifleri.com/2021/08/25/urfa-kebap-tarifi-8.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://i.nefisyemektarifleri.com/2020/05/19/lahmacun-tarifi-8.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://i.nefisyemektarifleri.com/2020/05/19/pide-tarifi-8.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://i.nefisyemektarifleri.com/2020/05/19/manti-tarifi-8.jpg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://i.nefisyemektarifleri.com/2020/05/19/kofte-tarifi-8.jpg");
        }
    }
}
