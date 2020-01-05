using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTrackGame
{
    public partial class Form1 : Form
    {
        private readonly int NumberOfGuys = 3;
        private readonly int NumberOfDogs = 4;
        public Form1()
        {
            InitializeComponent();
            this.SetupRaceTrack();
        }

        public void SetupRaceTrack()
        {
            Random MyRandomizer = new Random();
            this.Guys = new Guy[this.NumberOfGuys];

            this.Guys[0] = new Guy()
            {
                Cash = 50,
                MyBet = null,
                MyLabel = this.label5,
                MyRadioButton = this.radioButton1,
                Name = "Joe"
            };

            this.Guys[1] = new Guy()
            {
                Cash = 75,
                MyBet = null,
                MyLabel = this.label6,
                MyRadioButton = this.radioButton2,
                Name = "Bob"
            };

            this.Guys[2] = new Guy()
            {
                Cash = 45,
                MyBet = null,
                MyLabel = this.label7,
                MyRadioButton = this.radioButton3,
                Name = "Al"
            };

            this.Greyhounds = new Greyhound[this.NumberOfDogs];

            this.Greyhounds[0] = new Greyhound()
            {
                MyPictureBox = this.pictureBox1,
                StartingPosition = this.pictureBox1.Left,
                RaceTrackLength = this.racetrackPictureBox.Width - this.pictureBox1.Width,
                Randomizer = MyRandomizer
            };

            this.Greyhounds[1] = new Greyhound()
            {
                MyPictureBox = this.pictureBox2,
                StartingPosition = this.pictureBox2.Left,
                RaceTrackLength = this.racetrackPictureBox.Width - this.pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            this.Greyhounds[2] = new Greyhound()
            {
                MyPictureBox = this.pictureBox3,
                StartingPosition = this.pictureBox3.Left,
                RaceTrackLength = this.racetrackPictureBox.Width - this.pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            this.Greyhounds[3] = new Greyhound()
            {
                MyPictureBox = this.pictureBox4,
                StartingPosition = this.pictureBox4.Left,
                RaceTrackLength = this.racetrackPictureBox.Width - this.pictureBox4.Width,
                Randomizer = MyRandomizer
            };

            //sett up labels:
            this.radioButton1.Text = $"{this.Guys[0].Name} has {this.Guys[0].Cash}";
            this.radioButton2.Text = $"{this.Guys[1].Name} has {this.Guys[1].Cash}";
            this.radioButton3.Text = $"{this.Guys[2].Name} has {this.Guys[2].Cash}";

            this.radioButton1.Text = $"{this.Guys[0].Name} has {this.Guys[0].Cash}";
            this.radioButton2.Text = $"{this.Guys[1].Name} has {this.Guys[1].Cash}";
            this.radioButton3.Text = $"{this.Guys[2].Name} has {this.Guys[2].Cash}";

            this.label5.Text = $"{this.Guys[0].Name} hasn't placed a bet";
            this.label6.Text = $"{this.Guys[1].Name} hasn't placed a bet";
            this.label7.Text = $"{this.Guys[2].Name} hasn't placed a bet";

            this.label10.Text = "Race not started";

            foreach (var guy in this.Guys)
            {
                //guy.ClearBet();
                guy.UpdateLabels();
            }


        }
        //Race button:
        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButton1.Text = $"{this.Guys[0].Name} has {this.Guys[0].Cash}";
            this.label1.Text = $"{this.Guys[0].Name}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label10.Text = $"The Race has started!";
            for (int index = 0; index < this.Greyhounds.Length; index++)
            {
                
                if (this.Greyhounds[index].Run())
                {
                    this.timer1.Stop();
                    this.label10.Text = "Race finished!";

                    PayoutWinners(index);

                     string message =
                        $"Dog number #{index + 1} is the winner";
                    const string caption = "Winner";
                    var result = MessageBox.Show(message, caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Question);

                    UpdateCash();


                    for (int index2 = 0; index2 < this.Greyhounds.Length; index2++)
                    {
                        this.Greyhounds[index2].TakeStartingPosition();
                    }

                    //foreach (var guy in this.Guys)
                    //{
                    //    guy.ClearBet();
                    //}

                }
            }
        }

        private void UpdateCash()
        {
            for (int index = 0; index < this.NumberOfGuys; index++)
            {
                this.Guys[index].MyRadioButton.Text = $"{this.Guys[index].Name} has {this.Guys[index].Cash}";
            }
        }

        private void PayoutWinners(int winnerDog)
        {
            for(int index = 0; index < this.NumberOfGuys; index++)
            {
                //if (this.Guys[index].MyBet.Dog == winnerDog)
                //{
                //    this.Guys[index].Cash = 2 * this.Guys[index].MyBet.PayOut(winnerDog);
                //}
                //else
                //{
                //    this.Guys[index].Cash =+ this.Guys[index].MyBet.PayOut(winnerDog);
                //}
                this.Guys[index].Collect(winnerDog);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButton3.Text = $"{this.Guys[2].Name} has {this.Guys[2].Cash}";
            this.label1.Text = $"{this.Guys[2].Name}";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButton2.Text = $"{this.Guys[1].Name} has {this.Guys[1].Cash}";
            this.label1.Text = $"{this.Guys[1].Name}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            if (this.radioButton1.Checked)
            {
                this.Guys[0].PlaceBet((int)this.numericUpDown1.Value, (int)this.numericUpDown2.Value);
                this.label5.Text = $"{this.Guys[0].Name} bets {this.Guys[0].MyBet.Amount} on dog #{this.Guys[0].MyBet.Dog}";
                this.radioButton1.Text = $"{this.Guys[0].Name} has {this.Guys[0].Cash}";

            }

            if (this.radioButton2.Checked)
            {
                this.Guys[1].PlaceBet((int)this.numericUpDown1.Value, (int)this.numericUpDown2.Value);
                this.label6.Text = $"{this.Guys[1].Name} bets {this.Guys[1].MyBet.Amount} on dog #{this.Guys[1].MyBet.Dog}";
                this.radioButton2.Text = $"{this.Guys[1].Name} has {this.Guys[1].Cash}";
            }

            if (this.radioButton3.Checked)
            {
                this.Guys[2].PlaceBet((int)this.numericUpDown1.Value, (int)this.numericUpDown2.Value);
                this.label7.Text = $"{this.Guys[2].Name} bets {this.Guys[2].MyBet.Amount} on dog #{this.Guys[2].MyBet.Dog}";
                this.radioButton3.Text = $"{this.Guys[2].Name} has {this.Guys[2].Cash}";
            }

        }
    }
}
