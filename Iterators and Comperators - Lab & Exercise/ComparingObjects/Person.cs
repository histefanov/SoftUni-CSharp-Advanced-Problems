using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(params string[] info)
        {
            this.name = info[0];
            this.age = int.Parse(info[1]);
            this.town = info[2];
        }

        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.name);
            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
                if (result == 0)
                {
                    result = this.town.CompareTo(other.town);
                }
            }
            return result;
        }
    }
}
