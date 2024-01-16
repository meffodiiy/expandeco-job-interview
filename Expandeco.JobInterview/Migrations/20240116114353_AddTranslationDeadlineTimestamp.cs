using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expandeco.JobInterview.Migrations
{
    public partial class AddTranslationDeadlineTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Translations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedToId", "CreatedById", "TargetLanguageId", "Text", "Title" },
                values: new object[] { null, 10, 4, "Nobis ducimus eos sed deserunt officia sed soluta.", "provident aperiam fugiat" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedToId", "TargetLanguageId", "Text", "Title" },
                values: new object[] { 7, 4, "Voluptatem mollitia corporis adipisci.\nTempore aut quo consectetur.", "cupiditate repellat eligendi" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedToId", "CreatedById", "Text", "Title" },
                values: new object[] { 7, 10, "Libero et neque quam perferendis.", "autem voluptatem hic" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssignedToId", "CreatedById", "Text", "Title" },
                values: new object[] { null, 9, "consequatur", "ea vel facere" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssignedToId", "CreatedById", "TargetLanguageId", "Text", "Title" },
                values: new object[] { 4, 10, 3, "Est suscipit quo sint dolorem earum commodi esse.", "dolore quia ipsum" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedById", "TargetLanguageId", "Text", "Title" },
                values: new object[] { 10, 4, "Est voluptas id.\nVoluptatem qui et rerum corporis est dolorum illum libero.\nEt et exercitationem et ad ducimus.\nQuod eum et rerum aliquid nesciunt reprehenderit dolor commodi quibusdam.", "autem consectetur voluptatem" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssignedToId", "CreatedById", "SourceLanguageId", "Text", "Title" },
                values: new object[] { null, 9, 2, "totam", "corrupti voluptates aut" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title" },
                values: new object[] { null, 8, 2, 3, "Aut nobis deleniti.", "quidem sapiente nihil" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedById", "SourceLanguageId", "Text", "Title" },
                values: new object[] { 10, 2, "Qui blanditiis amet nemo velit.\nNon ullam repellendus ut vitae cumque consequatur corrupti vel ut.\nSimilique provident dolor impedit velit vero harum illum ut quos.\nIllum et voluptatibus et accusantium incidunt.\nMinima dolore consequatur.", "ea nesciunt eligendi" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssignedToId", "TargetLanguageId", "Text", "Title" },
                values: new object[] { 6, 4, "Eos consectetur delectus unde incidunt.\nQui voluptatem a quia est amet.\nQuia voluptatibus quo error.\nIure quis laboriosam quidem minima.\nDicta tempore ut cum molestiae voluptate et.", "aliquam debitis culpa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Natália Raková");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jana Slotová");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Arnold Tatar");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Zdenka Pašková");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Karol Madej");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Silvia Dvončová");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Valéria Maslová");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Žigmund Kostrec");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Ela Krajčová");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Teodor Mináč");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Translations");

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedToId", "CreatedById", "TargetLanguageId", "Text", "Title" },
                values: new object[] { 5, 8, 3, "Quod atque inventore qui iusto ea atque. Ut dolor architecto iure voluptatem ipsam dolorem minima incidunt. In asperiores earum.", "deleniti asperiores est" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedToId", "TargetLanguageId", "Text", "Title" },
                values: new object[] { null, 3, "Unde velit ipsa sit et.\nDeleniti esse quo voluptatem reprehenderit qui quas explicabo.\nVoluptatem sit velit voluptas expedita aliquid.\nAnimi nihil quis.\nDolorem perferendis et velit sint quam.", "est quis molestiae" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedToId", "CreatedById", "Text", "Title" },
                values: new object[] { 6, 8, "Minima temporibus facilis illo.\nRem eaque blanditiis.\nEst repellendus consequatur earum corrupti mollitia suscipit ipsa tenetur necessitatibus.\nTemporibus sint ut ut voluptatem est.\nQuaerat quae fugiat aliquid aliquam.", "ad dolores pariatur" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AssignedToId", "CreatedById", "Text", "Title" },
                values: new object[] { 3, 8, "Consectetur quidem fugit quo. Cupiditate itaque qui saepe dolorum. Quis voluptas omnis tempore.", "ut qui aliquid" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AssignedToId", "CreatedById", "TargetLanguageId", "Text", "Title" },
                values: new object[] { null, 8, 4, "Repellendus enim consequatur natus sed corrupti et enim. Sit voluptates rerum. Id odit eum blanditiis harum at illum perferendis aliquam reprehenderit. Eaque eos velit omnis. Vel odit magni.", "quia autem non" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedById", "TargetLanguageId", "Text", "Title" },
                values: new object[] { 9, 3, "Molestias laboriosam quia rem corporis ipsa.\nQuod et eveniet magni non.\nNon aut est cupiditate in nostrum at voluptatem.\nTempora dolor quibusdam ad.\nOdio id quia unde quia veritatis occaecati placeat ab beatae.", "facilis suscipit dicta" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AssignedToId", "CreatedById", "SourceLanguageId", "Text", "Title" },
                values: new object[] { 6, 8, 1, "Non dolor aperiam consequatur nobis iure ut nisi minima fugit. Cum doloremque quae et alias. Ut a accusamus dolor dolor fugiat non a similique.", "eum saepe non" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title" },
                values: new object[] { 3, 10, 1, 4, "Enim eos repellendus nesciunt quia totam itaque id. Et odit officia eum explicabo eos ipsa quis omnis et. Quas at sed magnam quas in earum aspernatur natus eaque. Voluptatem quia ullam quos atque ipsum quo alias. Eveniet autem et voluptas doloremque.", "dolor quidem suscipit" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedById", "SourceLanguageId", "Text", "Title" },
                values: new object[] { 8, 1, "Maxime sed expedita animi cupiditate quo.\nAt aut nulla eum.", "ut in ex" });

            migrationBuilder.UpdateData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AssignedToId", "TargetLanguageId", "Text", "Title" },
                values: new object[] { 3, 3, "quo", "in omnis sed" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ondrej Kolnik");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Bohumil Beňo");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Bernard Krajčo");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Patrik Krajíček");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Ignác Senko");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Dobromila Lubinová");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Klement Thomka");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Silvester Jánošík");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Štefánia Liptáková");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Silvia Dvončová");
        }
    }
}
