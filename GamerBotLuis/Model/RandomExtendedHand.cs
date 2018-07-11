using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamerBot.Model
{
    [Serializable]
    public class RandomExtendedHand : RandomHand
    {
        private static void AddRandomHands_To_Dictionary()
        {
            WinnnerRandomHands.Add(4, ExtendedHandType.Lizard);
            WinnnerRandomHands.Add(5, ExtendedHandType.Spock);
        }

        static RandomExtendedHand()
        {
            AddRandomHands_To_Dictionary();
            GetRandomHand();
        }  
    }
}