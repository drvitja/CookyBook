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
    }
}