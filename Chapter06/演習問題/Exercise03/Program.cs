
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
            var str = text.ToLower().Replace(" ", "");

            //辞書(ディクショナリ)を使った集計
            var alphDicCount = Enumerable.Range('a', 26).ToDictionary(num => (char)num, num => 0);

            foreach (var c in str) {
                ++alphDicCount[c];
            }

            foreach (var item in alphDicCount) {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }

            Console.WriteLine();    //改行

            //配列を用いた集計
            var array = Enumerable.Repeat(0, 26).ToArray();

            foreach (var alph in str) {
                array[alph - 'a']++;
            }
            for (char ch = 'a'; ch <= 'z'; ch++) {
                Console.WriteLine($"{ch}:{array[ch - 'a']}");
            }
        }
    }
}
