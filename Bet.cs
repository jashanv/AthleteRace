using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteRace
{
    public class Bet : Athlete
    {
        public int BetAmount { get; set; }
        public Bettor bettor { get; set; }
        public int car { get; set; }
        public int multiplier = 4;

        public int Payout(int WinningAthlete)
        {
            if (WinningAthlete == car)
            {
                return BetAmount * multiplier;
            }
            else
            {
                return (0 - BetAmount);
            }
        }
    }
}
