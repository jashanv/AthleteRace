using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AthleteRace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int StartRace = Athlete1.Left;
            int RaceTrackLength = RaceTrack.Width - Athlete1.Right;

            Data.athletes[0] = new Athlete() { AthletePicture = Athlete1, finishingPosition = RaceTrackLength, startingPosition = StartRace };
            Data.athletes[1] = new Athlete() { AthletePicture = Athlete2, finishingPosition = RaceTrackLength, startingPosition = StartRace };
            Data.athletes[2] = new Athlete() { AthletePicture = Athlete3, finishingPosition = RaceTrackLength, startingPosition = StartRace };
            Data.athletes[3] = new Athlete() { AthletePicture = Athlete4, finishingPosition = RaceTrackLength, startingPosition = StartRace };
            Data.athletes[4] = new Athlete() { AthletePicture = Athlete5, finishingPosition = RaceTrackLength, startingPosition = StartRace };

            Data.bettors[0] = new Bettor() { balance = 65, activityLabel = label4, bettorsList = radioButton1, name = "Player 1" };
            Data.bettors[1] = new Bettor() { balance = 75, activityLabel = label5, bettorsList = radioButton2, name = "Player 2" };
            Data.bettors[2] = new Bettor() { balance = 55, activityLabel = label6, bettorsList = radioButton3, name = "Player 3" };

            // Sets the default values to the labels
            Data.bettors[0].UpdateActivityLabels();
            Data.bettors[1].UpdateActivityLabels();
            Data.bettors[2].UpdateActivityLabels();
            Data.bettors[0].ResetStats();
            Data.bettors[1].ResetStats();
            Data.bettors[2].ResetStats();
        }

        private void PlaceBet_Click(object sender, EventArgs e)
        {
            Data.bettors[Data.CurrentGambler].PlaceABet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Data.bettors[Data.CurrentGambler].UpdateActivityLabels();
        }

        private void Race_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Race.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.athletes.Length; i++)
            {
                Data.athletes[Data.rand.Next(0, 5)].Run();
                if (Data.athletes[i].Run())
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    Race.Enabled = true;
                    DeclareWinner(i + 1);
                }
            }
        }

        private void ResetPositions()
        {
            Data.athletes[0].ResetAthletePosition();
            Data.athletes[1].ResetAthletePosition();
            Data.athletes[2].ResetAthletePosition();
            Data.athletes[3].ResetAthletePosition();
            Data.athletes[4].ResetAthletePosition();
        }

        private void ResetBids()
        {
            label4.Text = "Player 1 hasn't placed a bet.";
            label5.Text = "Player 2 hasn't placed a bet.";
            label6.Text = "Player 3 hasn't placed a bet.";
        }

        private void DeclareWinner(int Winner)
        {
            MessageBox.Show("Athlete #" + Winner + " is the Winning Athlete");
            for (int i = 0; i < Data.bettors.Length; i++)
            {
                Data.bettors[i].CollectWinnings(Winner);
                Data.bettors[i].UpdateActivityLabels();
                ResetPositions();
                ResetBids();
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Data.CurrentGambler = 0;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Data.CurrentGambler = 1;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Data.CurrentGambler = 2;
        }
    }
}
