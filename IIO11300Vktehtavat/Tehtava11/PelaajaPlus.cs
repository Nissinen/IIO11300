using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava11
{
   public partial class Pelaajat
    {
        public string Kokonimi
        {
            get { return this.etunimi + " " + this.sukunimi + "@" + this.seura; }
        }
    }
}
