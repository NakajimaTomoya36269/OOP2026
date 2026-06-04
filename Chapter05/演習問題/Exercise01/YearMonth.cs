using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //5.1.1
    public class YearMonth {

        public int Year { get; init; }

        public int Month { get; init; }

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        public bool Is21Century => 2001 <= Year && Year <= 2100;

        public YearMonth AddOneMonth() {
            int year = Year;
            int month = Month;

            month++;

            if (month.Equals(13)) {
                year++;
                month = 1;
            }

            var yearMonth = new YearMonth(year, month);

            return yearMonth;
        }

        public override string ToString() {
            return Year + "年" + Month + "月";
        }
    }
}
