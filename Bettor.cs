using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AthleteRace
{
    public class Bettor : Bet
    {
        public string name { get; set; }
        public int balance { get; set; }
        public Bet CurrentBet;

        public RadioButton bettorsList { get; set; }
        public Label activityLabel { get; set; }

        public void UpdateActivityLabels()
        {
            bettorsList.Text = name + " has $" + balance;
        }

        public void ResetStats()
        {
            CurrentBet = null;
            activityLabel.Text = name + " hasn't placed a bet";
        }

        public bool PlaceABet(int Amount, int BidAthlete)
        {
            this.CurrentBet = new Bet() { BetAmount = Amount, car = BidAthlete };

            if (Amount <= balance)
            {
                activityLabel.Text = this.name + " has placed $" + Amount + " on Athlete #" + BidAthlete;
                this.UpdateActivityLabels();
                return true;
            }
            else
            {
                MessageBox.Show(this.name + " doesn't have enough money to cover for the bet!");
                this.CurrentBet = null;
                return false;
            }
        }

        public void CollectWinnings(int WinningGambler)
        {
            if (this.CurrentBet != null)
            {
                balance += CurrentBet.Payout(WinningGambler);
                ResetStats();
                UpdateActivityLabels();
            }
        }
    }
}
