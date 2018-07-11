using GamerBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamerBot.Logics
{
    [Serializable]
    public class ClassicRockPaperScissorsGame : IRockPaperScissorsGame
    {
        internal Dictionary<string, List<HandType>> WinnerHands = new Dictionary<string, List<HandType>>()
        {
            {HandType.None.Name, new List<HandType>{HandType.None} },
            {HandType.Stone.Name, new List<HandType>{HandType.Scissors} },
            {HandType.Paper.Name, new List<HandType>{HandType.Stone} },
            {HandType.Scissors.Name, new List<HandType>{HandType.Paper} },
        };

        public HandType Play(HandType hand1, HandType hand2)
        {
            HandType winnerHand;
            bool anyoneWins = (hand1 == HandType.None || hand2 == HandType.None);
            bool deuce = (hand1.Name == hand2.Name);
            if (deuce)
            {
                winnerHand = HandType.None;
            }
            else
            {
                winnerHand = GetWinnerHand(hand1, hand2);
            }

            return winnerHand;
        }

        public HandType GetWinnerHand(HandType hand1, HandType hand2)
        {
            HandType winner = hand2;

            if (WinnerHands[hand1.Name].Any(x => x.Name == hand2.Name))
            {
                winner = hand1;
            }

            return winner;
        }
    }
}