using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Livro_De_Receitas.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Portions_Ingredients_IngredientId",
                table: "Portions");

            migrationBuilder.DropForeignKey(
                name: "FK_Portions_Recipes_RecipeId",
                table: "Portions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Portions_IngredientId",
                table: "Portions");

            migrationBuilder.DropIndex(
                name: "IX_Portions_RecipeId",
                table: "Portions");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Portions");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Portions");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Recipes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "Portions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categories",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "PortionRecipe",
                columns: table => new
                {
                    PortionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortionRecipe", x => new { x.PortionsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_PortionRecipe_Portions_PortionsId",
                        column: x => x.PortionsId,
                        principalTable: "Portions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortionRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoriesId",
                table: "Recipes",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Portions_IngredientsId",
                table: "Portions",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_PortionRecipe_RecipesId",
                table: "PortionRecipe",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portions_Ingredients_IngredientsId",
                table: "Portions",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoriesId",
                table: "Recipes",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portions_Ingredients_IngredientsId",
                table: "Portions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoriesId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "PortionRecipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CategoriesId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Portions_IngredientsId",
                table: "Portions");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Portions");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Portions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Portions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Portions_IngredientId",
                table: "Portions",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Portions_RecipeId",
                table: "Portions",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Portions_Ingredients_IngredientId",
                table: "Portions",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portions_Recipes_RecipeId",
                table: "Portions",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
