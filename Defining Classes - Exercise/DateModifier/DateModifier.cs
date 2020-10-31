using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public int Difference { get; set; }

        public void CalculateDifference(string firstDate, string secondDate)
        {
            DateTime startDate = Convert.ToDateTime(firstDate);
            DateTime endDate = Convert.ToDateTime(secondDate);
            Difference = Math.Abs((endDate - startDate).Days);
        }
    }
}
