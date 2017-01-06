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
    public class BooksDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<Book> GetAllByCategory(string CategoryId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Books where CategoryId=@CategoryId";
                var param = new { CategoryId = CategoryId };
                var results = conn.Query<Book>(strSql,param);
                return results;
            }
        }

        public void DeleteBooksByCategory(string CategoryId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Books where CategoryId=@CategoryId";
                var param = new { CategoryId = CategoryId };
                try
                {
                    conn.Execute(strSql,param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error : "+sqlEx.Message);
                }
            }
        }

        public void Insert(Book book)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Books(AuthorID,CategoryID,Title,Price) values(@AuthorID,@CategoryID,@Title,@Price)";
                var param = new { AuthorID = book.AuthorID, CategoryID = book.CategoryID, Title = book.Title, Price = book.Price };
                try
                {
                    conn.Execute(strSql,param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error : " + sqlEx.Message);
                }
            }
        }
    }
}