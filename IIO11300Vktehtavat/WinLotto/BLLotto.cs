using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLotto
{
    class BLLotto
    {
        private Int32 rivit;

        public Int32 Rivit
        {
            get { return rivit; }
            set { rivit = value; }
        }
        public Int32 Maara
        {
            get
            {
                return rivit;
            }
        }
        public string TulostaSuomiRivit()
        {
            Int32 luku = 0;
            string jono = "";
            Random r = new Random();
            for (int i = 0; i < rivit; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    luku = r.Next(1, 39);
                    jono = jono + " " + luku.ToString();
                }
                jono = jono + Environment.NewLine;
            //    textTulosta.Text = jono.ToString();
            }
            return jono;
        }
        public string TulostaVikingRivit()
        {
            Int32 luku = 0;
            string jono = "";
            Random r = new Random();
            for (int i = 0; i < rivit; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    luku = r.Next(1, 48);
                    jono = jono + " " + luku.ToString();
                }
                jono = jono + Environment.NewLine;
                //    textTulosta.Text = jono.ToString();
            }
            return jono;
        }
        public string TulostaEuroRivit()
        {
            Int32 luku = 0;
            string jono = "";
            Random r = new Random();
            for (int i = 0; i < rivit; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    luku = r.Next(1, 50);
                    jono = jono + " " + luku.ToString();
                }

                jono = jono + " +";

                for (int j = 0; j < 2; j++)
                {
                    luku = r.Next(1, 8);
                    jono = jono + " " + luku.ToString();
                }
                jono = jono + Environment.NewLine;
                //    textTulosta.Text = jono.ToString();
            }
            return jono;
        }
    }
}
