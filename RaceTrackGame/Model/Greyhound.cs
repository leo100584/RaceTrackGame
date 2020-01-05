using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrackGame
{
    using System.Windows.Forms;

    public class Greyhound
    {
        public int StartingPosition;

        public int RaceTrackLength;

        public PictureBox MyPictureBox;

        public int Location = 0;

        public int Distance;

        public Random Randomizer;

        public bool Run()
        {
            //int move = this.Randomizer.Next(1, 4);
            this.Distance = this.Randomizer.Next(1, 4)*10;
            this.Location += this.Distance;

            this.MyPictureBox.Left = this.StartingPosition + this.Location;

            if (this.MyPictureBox.Left >= this.RaceTrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public void TakeStartingPosition()
        {
            this.Location = 0;
            this.MyPictureBox.Left = this.StartingPosition;
        }
    }
}
