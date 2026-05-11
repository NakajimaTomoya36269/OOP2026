
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            // 2.1.3
            var songs = new Song[] {
                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
                new Song("I Will Always Love You", "Whitney Houston", 273),
            };
            PrintSongs(songs);
        }

        //2.1.4
        private static void PrintSongs(Song[] songs) {

            foreach (var song in songs) {
                int minute = song.Length / 60;
                int second = song.Length % 60;

                if(second < 10) {
                    Console.WriteLine($"{song.Title}, {song.ArtistName}, {minute}:0{second}");
                } else {
                    Console.WriteLine($"{song.Title}, {song.ArtistName}, {minute}:{second}");
                }
            }
        }
    }
}
