using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamerBot.Model
{
    [Serializable]
    public class ExtendedHandType : HandType
    {
        static ExtendedHandType()
        {
            Lizard = new ExtendedHandType(nameof(Lizard));
            Spock = new ExtendedHandType(nameof(Spock));
        }
        protected ExtendedHandType(string name)
            : base(name)
        {

        }
        public static ExtendedHandType Lizard { get; }
        public static ExtendedHandType Spock { get; }
    }
}
