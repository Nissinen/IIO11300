using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Tehtava10
{
    class DBPelaajat
    {

        public static DataTable GetPelaajat(string connStr)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT id, etunimi, sukunimi, seura, arvo FROM pelaajat";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Pelaajat");
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int UpdatePelaaja(string connStr, int id, string name, string author, string country, int year)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string sql = string.Format("UPDATE books SET name=@Nimi, author=@Kirjailija, country='{1}', year={2} WHERE id={0}", id, country, year);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //lisätään parametrit
                    MySqlParameter sp;
                    sp = new MySqlParameter("Nimi", SqlDbType.NVarChar);
                    sp.Value = name;
                    cmd.Parameters.Add(sp);
                    sp = new MySqlParameter("Kirjailija", SqlDbType.NVarChar);
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
