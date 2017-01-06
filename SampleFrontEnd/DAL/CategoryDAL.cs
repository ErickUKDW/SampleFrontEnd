using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Configuration;
using SampleFrontEnd.Models;
using System.Data.SqlClient;
using Dapper;

namespace SampleFrontEnd.DAL
{
    public class CategoryDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Categories order by CategoryName";
                var results = conn.Query<Category>(strSql);

                return results;
            }
        }

        public IEnumerable<Category> GetAllByName(string categoryName)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Categories 
                                  where CategoryName like @CategoryName 
                                  order by CategoryName asc";
                var pars = new { CategoryName = "%" + categoryName + "%" };
                return conn.Query<Category>(strSql, pars);
            }
        }

        public void Insert(Category category)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Categories(CategoryName) values(@CategoryName)";
                var param = new { CategoryName = category.CategoryName };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error : "+sqlEx.Message);
                }
                conn.Close();
            }
        }


    }
}