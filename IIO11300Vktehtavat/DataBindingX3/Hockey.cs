using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingX3
{
    public class HockeyPlayer : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            set { name = value; Notify("Name"); Notify("NameAndNumber"); }
            get { return name; }
        }
        private string number;
        public string Number
        {
            get { return number; }
            set { number = value; Notify("Number"); Notify("NameAndNumber"); }
        }
        public string NameAndNumber
        {
            get
            {
                return name + "#" + number;
            }
        }
        public HockeyPlayer()
        {

        }
        public HockeyPlayer(string name, string number)
        {
            this.name = name;
            this.number = number;
        }
        //methods
        public override string ToString()
        {
            return name + "#" + number;
        }
        //INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
    //constructiors
   
    public class HockeyTeam
    {
        #region PROPERTIES
        // huom public field ei kelpaa WPF:n databindingissä, pitää olla property
        public string Name { get; set; }
        public string City { get; set; }
        #endregion
        #region CONSTRUCTORS
        public override string ToString()
        {
            return Name + "@" + City;
        }
        public HockeyTeam()
        {
            Name = "";
            City = "unknown";
        }
        public HockeyTeam(string name, string city)
        {
            Name = name;
            City = city;
        }
        #endregion
    }
        public class HockeyLeague
        {
        //perustetaan SMliiga,
        List<HockeyTeam> teams = new List<HockeyTeam>();
        public HockeyLeague()
        {
            // perustetaan SMLiiga, sisältää X kpl joukkueita
            teams.Add(new HockeyTeam("HIFK", "HELSINKI"));
            teams.Add(new HockeyTeam("JYP", "JYVÄSKYLÄ"));
            teams.Add(new HockeyTeam("PELICANS", "LAHTI"));
            teams.Add(new HockeyTeam("KALPA", "KUOPIO"));

        }
          public List<HockeyTeam> GetTeams()
        {
            return teams;
        }
     }
 }

