using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Impl
{
    public class CookBookRepository : ICookBookRepository
    {
        public CookBookRepository()
        {
        }

        public Ingredient[] GetIngredients()
        {
            List<Ingredient> Ingredients = new List<Ingredient>();

            string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Ingredient";

            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.Id = reader.GetInt32(reader.GetOrdinal("Ingredient_ID"));
                    ingredient.Title = reader.GetString(reader.GetOrdinal("Title"));
                    Ingredients.Add(ingredient);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return Ingredients.ToArray();
        }

        public Recipe[] GetRecipes()
        {
            List<Recipe> Recipes = new List<Recipe>();

            string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Recipe";

            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Recipe cookRecipe = new Recipe();
                    cookRecipe.Id = reader.GetInt32(0);
                    cookRecipe.Title = reader.GetString(reader.GetOrdinal("Title"));
                    cookRecipe.Description = reader.GetString(reader.GetOrdinal("Description"));
                    cookRecipe.Preparation = reader.GetString(reader.GetOrdinal("Preparation"));
                    cookRecipe.Duration = reader.GetTimeSpan(reader.GetOrdinal("Duration"));
                    Recipes.Add(cookRecipe);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return Recipes.ToArray();
        }
       

        public Nutrition[] GetNutritions()
        {
            List<Nutrition> Nutritions = new List<Nutrition>();

            string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Nutrition";

            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nutrition nutrition = new Nutrition();
                    nutrition.Id = reader.GetInt32(reader.GetOrdinal("Ingredient_ID"));
                    nutrition.Title = reader.GetString(reader.GetOrdinal("Title"));
                    nutrition.Add(nutrition);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return Nutritions.ToArray();
        }
        public void SaveRecipe(Recipe recipe)
        {
            string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = String.Format("INSERT INTO Recipe (Recipe_ID, Title, Description, Preparation, Duration) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",recipe.Id,recipe.Title,recipe.Description,recipe.Preparation,recipe.Duration);

            try
            {
                con.Open();
                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public Category[] GetCategory()
        {
            List<Category> CategoryList = new List<Category>();

            string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Category";

            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.Id = reader.GetInt32(0);
                    category.Title = reader.GetString(reader.GetOrdinal("Title"));
                    category.Description = reader.GetString(reader.GetOrdinal("Description"));
                    CategoryList.Add(category);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return CategoryList.ToArray();
        }
    }
}