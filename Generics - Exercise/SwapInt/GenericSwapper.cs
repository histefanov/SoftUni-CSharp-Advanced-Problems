using _01.GenericBoxOfString;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericSwapMethodStrings
{
    public static class GenericMethods
    {
        public static List<Box<T>> Swap<T>(List<Box<T>> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex].Content;
            list[firstIndex].Content = list[secondIndex].Content;
            list[secondIndex].Content = temp;
            return list;
        }
    }
}
