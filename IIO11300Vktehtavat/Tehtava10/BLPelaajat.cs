using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10
{
    [Serializable]
    public class Pelaaja
    {
        #region PROPERTIES
        private string etunimi;
        public string Etunimi
        {
            get { return etunimi; }
            set { etunimi = value; }
        }

        private string sukunimi;
        public string Sukunimi
        {
            get { return sukunimi; }
            set { sukunimi = value; }
        }

        private string joukkue;
        public string Joukkue
        {
            get { return joukkue; }
            set { joukkue = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
        }

        private int siirtohinta;
        public int Siirtohinta
        {
            get { return siirtohinta; }
            set { siirtohinta = value; }
        }
        #endregion
        #region CONSTRUCTORS
        public Pelaaja()
        {

        }
        public Pelaaja(int id)
        {
            this.id = id;
        }

        public Pelaaja( string etunimi, string sukunimi, string joukkue, int siirtohinta)
        {
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.joukkue = joukkue;
            this.siirtohinta = siirtohinta;
        }

        public Pelaaja(int id, string etunimi, string sukunimi, string joukkue, int siirtohinta)
        {
            this.id = id;
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.joukkue = joukkue;
            this.siirtohinta = siirtohinta;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return etunimi + " " + sukunimi + ", " + joukkue;
        }
        #endregion

    }
    public class PelaajaLista
    {
        private static string cs = Tehtava10.Properties.Settings.Default.Tietokanta; 

        public static List<Pelaaja> GetPelaajat(Boolean useDB)
        {
            DataTable dt;
            List<Pelaaja> temp = new List<Pelaaja>();
            //haetaan kirjat db-kerroksen palauttama datatable mapataan olioiksi eli tehdään ormi
            try
            {
                    dt = DBPelaajat.GetPelaajat(cs);

                //Tehdään ORM eli DataTablen rivit muutetaan olioiksi
                Pelaaja pl;
                foreach (DataRow dr in dt.Rows)
                {
                    pl = new Pelaaja((int)dr[0]);
                    pl.Etunimi = dr["etunimi"].ToString();
                    pl.Sukunimi = dr["sukunimi"].ToString();
                    pl.Joukkue = dr["seura"].ToString();
                    pl.Siirtohinta = (int)dr["arvo"];
                    //olio lisätään kokoelmaan
                    temp.Add(pl);

                }
                return temp;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UpdatePelaaja(Pelaaja book)
        {
            try
            {
                int lkm = DBPelaajat.UpdatePelaaja(cs, book.Id,book.Etunimi,book.Sukunimi,book.Joukkue,book.Siirtohinta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
