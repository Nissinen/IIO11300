using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BooksORM
{
    class DBBooks
    {
        public static DataTable GetTestData()
        {
            //luodaan "oikeanlainen" dataTable leikkidatasta
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("author", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("year", typeof(int));
            //luodaan rivit
            dt.Rows.Add(11, "peten päiväkirja", "pete", "petenpaja", 2010);
            dt.Rows.Add(11, "paten päiväkirja", "pate", "patenpaja", 2011);
            return dt;
        }
        public static DataTable GetBooks(string connStr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "SELECT id, name, author, country, year FROM books";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Books");
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int UpdateBook(string connStr, int id, string name, string author, string country, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = string.Format("UPDATE books SET name=@Nimi, author=@Kirjailija, country='{1}', year={2} WHERE id={0}", id, country, year);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //lisätään parametrit
                    SqlParameter sp;
                    sp = new SqlParameter("Nimi", SqlDbType.NVarChar);
                    sp.Value = name;
                    cmd.Parameters.Add(sp);
                    sp = new SqlParameter("Kirjailija", SqlDbType.NVarChar);
                    sp.Value = author;
                    cmd.Parameters.Add(sp);
                    int lkm = cmd.ExecuteNonQuery();
                    return lkm;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
