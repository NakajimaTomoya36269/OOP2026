using Exercise01;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            // 5.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2024, 12),
            };

            Console.WriteLine("5.2.2");
            Exercise2(ymCollection);

            Console.WriteLine("5.2.4");
            Exercise4(ymCollection);


            Console.WriteLine("5.2.5");
            Exercise5(ymCollection);
        }

        private static void Exercise2(YearMonth[] ymCollection) {
            foreach (var ymItem in ymCollection) {
                Console.WriteLine(ymItem);
            }
            Console.WriteLine();
        }

        private static YearMonth? FindFirst21C(YearMonth[] ymCollection) {
            foreach (var ymItem in ymCollection) {
                if (ymItem.Is21Century) {
                    return ymItem;
                }
            }
            return null;
        }

        private static void Exercise4(YearMonth[] ymCollection) {
            if (FindFirst21C(ymCollection) is not null) {
                Console.WriteLine($"{FindFirst21C(ymCollection)?.Year}年\n");
            } else {
                Console.WriteLine("21世紀のデータはありません\n");
            }
        }

        private static void Exercise5(YearMonth[] ymCollection) {
            var ymAddOneMonth = ymCollection.Select(n => n.AddOneMonth()).ToArray();

            foreach (var ym in ymAddOneMonth) {
                Console.WriteLine(ym);
            }
        }
    }
}
