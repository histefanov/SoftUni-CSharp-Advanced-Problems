using _01.GenericBoxOfString;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericSwapMethodStrings
{
    public static class GenericMethods<T>
        where T : IComparable<T>
    {
        //public static List<Box<T>> Swap<T>(List<Box<T>> list, int firstIndex, int secondIndex)
        //{
        //    T temp = list[firstIndex].Content;
        //    list[firstIndex].Content = list[secondIndex].Content;
        //    list[secondIndex].Content = temp;
        //    return list;
        //}

        public static int GetNumberOfLargerElements(List<Box<T>> list, T element)
        {
            int counter = 0;
            list.ForEach(x =>
            {
                if (x.Content.CompareTo(element) > 0)
                {
                    counter++;
                }
            });
            return counter;
        }
    }
}
