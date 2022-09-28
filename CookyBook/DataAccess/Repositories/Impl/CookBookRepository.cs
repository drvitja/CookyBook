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
        public CookRecipe[] GetCookRecipes()
        {
            List<CookRecipe> cookRecipes = new List<CookRecipe>();

            string conString = "Data Source=(localdb)\\MsSqlLocalDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM CookRecipe";

            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CookRecipe cookRecipe = new CookRecipe();
                    cookRecipe.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    cookRecipe.Name = reader.GetString(reader.GetOrdinal("Name"));
                    cookRecipe.ShortDescription = reader.GetString(reader.GetOrdinal("Description"));
                    cookRecipe.Time = reader.GetTimeSpan(reader.GetOrdinal("WorkingTime"));
                    cookRecipes.Add(cookRecipe);
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

            return cookRecipes.ToArray();
        }
    }
}