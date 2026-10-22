using TextFileProcessor;

string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\Section04\Program.cs";
TextProcessor.Run<FileProgramProcessor>(path);

public class FileProgramProcessor : TextProcessor {

    private int _count = 0;
    private string? _search = "";

    protected override void Initialize(string fname) {
        _count = 0;
        Console.Write("カウントしたい単語：");
        _search = Console.ReadLine();
    }

    protected override void Execute(string line) {
        char[] delimiters = { ' ', '“', '”', '"', '\'', '.', ',', ':', '/' };
        var count = line.Split(delimiters).Count(s => s == _search);
        _count += count;
    }

    protected override void Terminate() =>
        Console.WriteLine("「{0}」は{1} つ出現します", _search, _count);
}
