using System;

namespace GamerBot.Model
{
    [Serializable]
    public class HandType
    {
        static HandType()
        {
            None = new HandType(nameof(None));
            Scissors = new HandType(nameof(Scissors));
            Paper = new HandType(nameof(Paper));
            Stone = new HandType(nameof(Stone));
        }

        protected HandType(string name)
        {
            this.Name = name;
        }

        public static HandType None { get; }
        public static HandType Scissors { get; }
        public static HandType Paper { get; }
        public static HandType Stone { get; }
        public string Name { get; }
    }
}