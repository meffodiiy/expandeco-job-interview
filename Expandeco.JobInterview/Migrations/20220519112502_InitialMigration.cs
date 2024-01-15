using Microsoft.EntityFrameworkCore.Migrations;

namespace Expandeco.JobInterview.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    TranslatedText = table.Column<string>(type: "TEXT", nullable: true),
                    SourceLanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    TargetLanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedToId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_SourceLanguageId",
                        column: x => x.SourceLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_TargetLanguageId",
                        column: x => x.TargetLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Users_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Angličtina" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Slovenčina" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Čeština" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Nemčina" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Manažér" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Prekladateľ" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Klient" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 1, "Ondrej Kolnik", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 2, "Bohumil Beňo", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 3, "Bernard Krajčo", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 4, "Patrik Krajíček", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 5, "Ignác Senko", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 6, "Dobromila Lubinová", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 7, "Klement Thomka", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 8, "Silvester Jánošík", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 9, "Štefánia Liptáková", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 10, "Silvia Dvončová", 3 });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 1, 5, 8, 2, 3, "Quod atque inventore qui iusto ea atque. Ut dolor architecto iure voluptatem ipsam dolorem minima incidunt. In asperiores earum.", "deleniti asperiores est", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 2, null, 8, 2, 3, "Unde velit ipsa sit et.\nDeleniti esse quo voluptatem reprehenderit qui quas explicabo.\nVoluptatem sit velit voluptas expedita aliquid.\nAnimi nihil quis.\nDolorem perferendis et velit sint quam.", "est quis molestiae", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 3, 6, 8, 2, 3, "Minima temporibus facilis illo.\nRem eaque blanditiis.\nEst repellendus consequatur earum corrupti mollitia suscipit ipsa tenetur necessitatibus.\nTemporibus sint ut ut voluptatem est.\nQuaerat quae fugiat aliquid aliquam.", "ad dolores pariatur", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 4, 3, 8, 2, 3, "Consectetur quidem fugit quo. Cupiditate itaque qui saepe dolorum. Quis voluptas omnis tempore.", "ut qui aliquid", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 5, null, 8, 2, 4, "Repellendus enim consequatur natus sed corrupti et enim. Sit voluptates rerum. Id odit eum blanditiis harum at illum perferendis aliquam reprehenderit. Eaque eos velit omnis. Vel odit magni.", "quia autem non", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 7, 6, 8, 1, 3, "Non dolor aperiam consequatur nobis iure ut nisi minima fugit. Cum doloremque quae et alias. Ut a accusamus dolor dolor fugiat non a similique.", "eum saepe non", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 9, null, 8, 1, 4, "Maxime sed expedita animi cupiditate quo.\nAt aut nulla eum.", "ut in ex", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 6, null, 9, 1, 3, "Molestias laboriosam quia rem corporis ipsa.\nQuod et eveniet magni non.\nNon aut est cupiditate in nostrum at voluptatem.\nTempora dolor quibusdam ad.\nOdio id quia unde quia veritatis occaecati placeat ab beatae.", "facilis suscipit dicta", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 8, 3, 10, 1, 4, "Enim eos repellendus nesciunt quia totam itaque id. Et odit officia eum explicabo eos ipsa quis omnis et. Quas at sed magnam quas in earum aspernatur natus eaque. Voluptatem quia ullam quos atque ipsum quo alias. Eveniet autem et voluptas doloremque.", "dolor quidem suscipit", null });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "SourceLanguageId", "TargetLanguageId", "Text", "Title", "TranslatedText" },
                values: new object[] { 10, 3, 10, 2, 3, "quo", "in omnis sed", null });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_AssignedToId",
                table: "Translations",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_CreatedById",
                table: "Translations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_SourceLanguageId",
                table: "Translations",
                column: "SourceLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_TargetLanguageId",
                table: "Translations",
                column: "TargetLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeId",
                table: "Users",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
