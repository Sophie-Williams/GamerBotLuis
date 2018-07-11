using GamerBot.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamerBot.Model
{
    public interface IRockPaperScissorsGame
    {
        HandType Play(HandType hand1, HandType hand2);
        HandType GetWinnerHand(HandType hand1, HandType hand2);
    }
}