using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.Repositories.Impl
{
    public class CookBookRepository<TEntity> : ICookBookRepository<TEntity> where TEntity : EntityBase
    {
        private readonly CookBookDbContext DBContext;

        public CookBookRepository(CookBookDbContext dBContext)
        {
            DBContext = dBContext;
        }

        public List<TEntity> GetEntities()
        {
            return DBContext.Set<TEntity>().ToList<TEntity>();
        }

        //Old versions of Get() / Save() / Delete() --> SQL
        //public Ingredient[] GetIngredients()
        //{
        //    List<Ingredient> Ingredients = new List<Ingredient>();

        //    string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

        //    SqlConnection con = new SqlConnection(conString);
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "SELECT * FROM Ingredient";

        //    try
        //    {
        //        con.Open();
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Ingredient ingredient = new Ingredient();
        //            ingredient.Id = reader.GetInt32(reader.GetOrdinal("Ingredient_ID"));
        //            ingredient.Title = reader.GetString(reader.GetOrdinal("Title"));
        //            Ingredients.Add(ingredient);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return Ingredients.ToArray();
        //}

        //public Recipe[] GetRecipes()
        //{
        //    List<Recipe> Recipes = new List<Recipe>();

        //    string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

        //    SqlConnection con = new SqlConnection(conString);
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "SELECT * FROM Recipe";

        //    try
        //    {
        //        con.Open();
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Recipe recipe = new Recipe();
        //            recipe.Id = reader.GetInt32(reader.GetOrdinal("Recipe_ID")); 
        //            recipe.Title = reader.GetString(reader.GetOrdinal("Title"));
        //            recipe.Description = reader.GetString(reader.GetOrdinal("Description"));
        //            recipe.Preparation = reader.GetString(reader.GetOrdinal("Preparation"));
        //            recipe.Duration = reader.GetTimeSpan(reader.GetOrdinal("Duration"));
        //            recipe.ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"));
        //            Recipes.Add(recipe);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return Recipes.ToArray();
        //}
        //public Nutrient[] GetNutrients()
        //{
        //    List<Nutrient> Nutrients = new List<Nutrient>();

        //    string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

        //    SqlConnection con = new SqlConnection(conString);
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "SELECT * FROM Nutrient";

        //    try
        //    {
        //        con.Open();
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Nutrient nutrient = new Nutrient();
        //            nutrient.Id = reader.GetInt32(reader.GetOrdinal("Nutrient_ID"));
        //            nutrient.Title = reader.GetString(reader.GetOrdinal("Title"));
        //            Nutrients.Add(nutrient);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return Nutrients.ToArray();
        //}
        //public Category[] GetCategory()
        //{
        //    List<Category> CategoryList = new List<Category>();

        //    string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

        //    SqlConnection con = new SqlConnection(conString);
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "SELECT * FROM Category";

        //    try
        //    {
        //        con.Open();
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Category category = new Category();
        //            category.Id = reader.GetInt32(0);
        //            category.Title = reader.GetString(reader.GetOrdinal("Title"));
        //            category.Description = reader.GetString(reader.GetOrdinal("Description"));
        //            CategoryList.Add(category);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return CategoryList.ToArray();
        //}

        //public void SaveRecipe(Recipe recipe)
        //{
        //    string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";

        //    SqlConnection con = new SqlConnection(conString);
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "INSERT INTO Recipe (Recipe_ID, Title, Description, Preparation, Duration) " + "VALUES (@id, @title, @descr, @prep, @dur)";
        //    SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
        //    SqlParameter descrParam = new SqlParameter("@descr", SqlDbType.Text);
        //    SqlParameter titleParam = new SqlParameter("@title", SqlDbType.Text);
        //    SqlParameter prepParam = new SqlParameter("@prep", SqlDbType.Text);
        //    SqlParameter durParam = new SqlParameter("@dur", SqlDbType.Time);
        //    idParam.Value = recipe.Id;
        //    descrParam.Value = recipe.Description;
        //    titleParam.Value = recipe.Title;
        //    prepParam.Value = recipe.Preparation;
        //    durParam.Value = recipe.Duration;
        //    cmd.Parameters.Add(idParam);
        //    cmd.Parameters.Add(descrParam);
        //    cmd.Parameters.Add(titleParam);
        //    cmd.Parameters.Add(prepParam);
        //    cmd.Parameters.Add(durParam);

        //    try
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        //public void DeleteRecipe(long id)
        //{
        //    string conString = "Data Source=(localdb)\\MsSqlLocalDB;Initial Catalog=CookyBook_DB;Integrated Security=True";
        //    SqlConnection con = new SqlConnection(conString);
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandText = "Delete From Recipe Where Recipe_ID = " + id;
        //}
        //public Recipe[] GetRecipes()
        //{
        //    return DBContext.Recipe!.ToArray();
        //}

        //public Ingredient[] GetIngredients()
        //{
        //    return DBContext.Ingredient!.ToArray();
        //}      

        //public Nutrient[] GetNutrients()
        //{
        //    return DBContext.Nutrient!.ToArray();
        //}

        //public Category[] GetCategories()
        //{
        //    return DBContext.Category!.ToArray();
        //}

        //public void SaveRecipe(Recipe recipe)
        //{
        //    this.DBContext.Recipe!.Add(recipe);
        //    this.DBContext.SaveChanges();
        //}

        //public void DeleteRecipe(long id)
        //{

        //    Recipe _recipe = this.DBContext.Recipe.Where(Recipe => Recipe.Id == id).FirstOrDefault();
        //    this.DBContext.Recipe.Remove(_recipe);
        //    this.DBContext.SaveChanges();
        //}




    }
}