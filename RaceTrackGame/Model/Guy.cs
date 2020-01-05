using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrackGame
{
    using System.Windows.Forms;

    public class Guy
    {
        public String Name;

        public Bet MyBet;

        public int Cash;

        public RadioButton MyRadioButton;

        public Label MyLabel;

        /*public Guy(String name, int cash)
        {
            this.Name = name;
            this.Cash = cash;
        }*/

        public void UpdateLabels()
        {
            //this.MyLabel.Text = this.MyBet.GetDescription();
            this.MyRadioButton.Text = $"Joe has {this.Cash} bucks";
        }

        public void ClearBet()
        {
            this.MyBet.Amount = 0;

        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            //this.MyBet.Amount = BetAmount;
            //this.MyBet.Dog = DogToWin;

            if (this.Cash >= BetAmount)
            {
                //make a new bet object here:
                this.MyBet = new Bet(BetAmount, DogToWin, this);
                this.Cash -= BetAmount;
                //update bet label
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Collect(int winner)
        {
            this.Cash += this.MyBet.PayOut(winner);

            ClearBet();

            this.UpdateLabels();
        }

    }
}
