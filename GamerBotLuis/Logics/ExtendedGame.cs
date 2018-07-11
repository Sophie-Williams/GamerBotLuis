using GamerBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamerBot.Logics
{
    [Serializable]
    public class ExtendedGame : ClassicRockPaperScissorsGame
    {  
        public void Add_ExtendedHands_To_WinnerHandsDictionary()
        {
            WinnerHands[ExtendedHandType.Stone.Name].Add(ExtendedHandType.Lizard);
            WinnerHands[ExtendedHandType.Scissors.Name].Add(ExtendedHandType.Lizard);
            WinnerHands[ExtendedHandType.Paper.Name].Add(ExtendedHandType.Spock);
            WinnerHands.Add(ExtendedHandType.Lizard.Name, new List<HandType> { ExtendedHandType.Spock, HandType.Paper });
            WinnerHands.Add(ExtendedHandType.Spock.Name, new List<HandType> { ExtendedHandType.Scissors, HandType.Stone });
        }
        public ExtendedGame()
        {
            Add_ExtendedHands_To_WinnerHandsDictionary();
        }
    }
}