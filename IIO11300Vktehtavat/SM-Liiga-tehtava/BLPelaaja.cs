using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM_liiga
{
   public class Pelaaja
    {
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

        private string siirtohinta;
        public string Siirtohinta
        {
            get { return siirtohinta; }
            set { siirtohinta = value; }
        }

        private string joukkue;
        public string Joukkue
        {
            get { return joukkue; }
            set { joukkue = value; }
        }

        public Pelaaja(string etunimi, string sukunimi, string siirtohinta, string joukkue)
        {
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.siirtohinta = siirtohinta;
            this.joukkue = joukkue;
        }
        public Pelaaja()
        {
        }
        public override string ToString()
        {
            //return base.ToString();
            return etunimi + " " + sukunimi + ", " + joukkue;
        }

        public String DataMuoto
        {
            get { return etunimi + ", " + sukunimi + ", " + joukkue + ", " + siirtohinta; }
        }

        public static void SaveDataToFile(List<Pelaaja> dataa, string filu)
        {
            //kirjoitetaan data tiedostoon, jos tiedosto on jo olemassa liitetään se olemassa olevaan, muuten luodaan uusi
            try
            {
                //tutkitaan onko tiedosto olemassa
                if (!System.IO.File.Exists(filu))
                {
                    //luodaan uusi
                    using (StreamWriter sw = File.CreateText(filu))
                    {
                        // käydään kokoelma läpi ja kirjoitetaan kukin mittausdata omalle riville
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
                else
                {
                    //lisätään olemassaolevaan tiedostoon
                    using (StreamWriter sw = File.AppendText(filu))
                    {
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Pelaaja> ReadDataFromFile(string filu)
        {
            //luetaan käyttäjän antamasta tiedostosta tekstirivejä ja muutetaan ne mittausdataksi
            try
            {
                if (File.Exists(filu))
                {
                    using (StreamReader sr = File.OpenText(filu))
                    {
                        //luetaan rivi kerrallaan tiedostoa
                        Pelaaja p;
                        List<Pelaaja> luetut = new List<Pelaaja>();
                        string rivi = "";
                        while ((rivi = sr.ReadLine()) != null)
                        {
                            // tutkitaan löytyykö sovittu erotinmerkki ; --> etupuolella on kellonaika ja sen jälkeen mittausarvo
                            if ((rivi.Length > 3) && rivi.Contains(","))
                            {
                                string[] split = rivi.Split(new char[] { ',' });
                                //luodaan tekstinpätkistä olio
                                p = new Pelaaja(split[0], split[1], split[3], split[2]);
                                luetut.Add(p);
                            }
                        }
                        //palautetaan
                        return luetut;
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
