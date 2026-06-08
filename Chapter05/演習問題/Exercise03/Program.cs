using Exercise01;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {

            var ym1 = new YearMonth(1980, 1);
            var ym2 = new YearMonth(1980, 1);

            if (ym1 == ym2) {
                Console.WriteLine("ym1とym2は等しい");
            } else {
                Console.WriteLine("ym1とym2は等しくない");
            }

            var ymCollection1 = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2024, 12),
            };

            var ymCollection2 = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2024, 12),
            };

            if (ymCollection1 == ymCollection2) {
                Console.WriteLine("ymCollection1とymCollection2は等しい");
            } else {
                Console.WriteLine("ymCollection1とymCollection2は等しくない");
            }
        }
    }
}
