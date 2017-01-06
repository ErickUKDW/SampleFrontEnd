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
    public class AuthorDAL
    {
        private string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<Author> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Authors order by FirstName";
                return conn.Query<Author>(strSql);
            }
        }

        public Author GetById(string authorID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Authors where AuthorID=@AuthorID";
                var par = new { AuthorID = authorID };
                return conn.Query<Author>(strSql, par).SingleOrDefault();
            }
        }
    }
}