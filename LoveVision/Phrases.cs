using System;
using System.Collections.Generic;
using System.Linq;

namespace LoveVision
{
    public class Phrases
    {
        public const string Beautiful = "You are beautiful";

        public const string LovelyDay = "Have a lovely day";

        public List<string> Sayings = new List<string>
        {
            Beautiful,
            LovelyDay
        };
    }

    internal static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}