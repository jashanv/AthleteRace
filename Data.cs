using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteRace
{
    abstract class Data
    {
        public static Athlete[] athletes = new Athlete[5];
        public static Bettor[] bettors = new Bettor[3];
        public static Random rand = new Random();
        public static int CurrentGambler { get; set; }
    }
}
