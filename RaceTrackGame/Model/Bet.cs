using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTrackGame
{
    public class Bet
    {
        public int Amount;

        public int Dog;

        public Guy Bettor;

        public Bet(int amount, int dog, Guy bettor)
        {
            this.Amount = amount;
            this.Dog = dog;
        }

        public String GetDescription()
        {
            return $"{this.Bettor.Name} bets {this.Bettor.MyBet.Amount} on #{this.Dog + 1}";
        }

        public int PayOut(int winner)
        {
            if (this.Dog == winner)
            {
                return this.Amount;
            }
            else
            {
                return -this.Amount;
            }
        }
    }
}
