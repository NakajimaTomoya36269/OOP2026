
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Console.WriteLine("問題8.1.1");
            Exercise1(text);
            Console.WriteLine();
            Console.WriteLine("問題8.1.2");
            Exercise2(text);
        }

        private static void Exercise1(string text) {
            //コミットのコメント(問題8.1.1完成)
            var str = text.ToUpper();
            var dict = new Dictionary<char, int>();

            foreach (var ch in str) {
                if ('A' <= ch && ch <= 'Z') {
                    if (dict.ContainsKey(ch)) {
                        ++dict[ch];
                    } else {
                        dict[ch] = 1;
                    }
                }
            }
            foreach (var sortDict in dict.OrderBy(d => d.Key)) {
                Console.WriteLine($"'{sortDict.Key}':{sortDict.Value}");
            }
        }

        private static void Exercise2(string text) {
            //コミットのコメント(問題8.1.2完成)

        }
    }
}
