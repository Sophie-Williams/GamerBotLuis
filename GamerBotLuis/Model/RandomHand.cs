using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamerBot.Model
{
    public class RandomHand
    {
        internal static Dictionary<int, HandType> WinnnerRandomHands = new Dictionary<int, HandType>()
        {
            {1, HandType.Scissors},
            {2, HandType.Stone},
            {3, HandType.Paper},
        };
        public static HandType GetRandomHand()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, WinnnerRandomHands.Count +1);
            HandType randomHand = WinnnerRandomHands[randomNumber];

            return randomHand;
        }
    }
}