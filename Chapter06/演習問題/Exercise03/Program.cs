
using System.Collections.Immutable;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion
        }

        private static void Exercise1(string text) {
            var count = text.Count(c => c.Equals(' '));
            Console.WriteLine($"空白数：{count}\n");
        }

        private static void Exercise2(string text) {
            Console.Write("検索：");
            var search = Console.ReadLine();
            Console.Write("置換：");
            var replace = Console.ReadLine();
            var replaced = text.Replace(search, replace);
            Console.WriteLine(replaced + "\n");
        }

        private static void Exercise3(string text) {

        }

        private static void Exercise4(string text) {
            string[] words = text.Split(' ');
            Console.WriteLine($"単語数：{words.Length}\n");
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words) {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }

        private static void Exercise6(string text) {
            var dict = new Dictionary<char, int>();

            foreach (var c in text) {
                if(c == ' ') {
                    continue;
                }
                if (dict.ContainsKey(c)) {
                    dict[c] += 1;
                } else {
                    dict[c] = 1;
                }
            }

            var sorted = dict.ToImmutableSortedDictionary();

            foreach (var item in sorted) {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }
    }
}
