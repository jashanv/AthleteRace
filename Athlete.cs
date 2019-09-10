using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AthleteRace
{
    public class Athlete
    {
        public int startingPosition { get; set; }
        public int finishingPosition { get; set; }
        public PictureBox AthletePicture { get; set; }
        private Random rand = new Random();

        public bool Run()
        {
            Point CurrentPos = AthletePicture.Location;
            CurrentPos.X += rand.Next(1, 8);
            AthletePicture.Location = CurrentPos;

            if (CurrentPos.X >= finishingPosition)
                return true;
            else
                return false;

            return false;
        }

        public void ResetAthletePosition()
        {
            AthletePicture.Left = startingPosition;
        }

    }
}
