namespace English.Words;

public class Word : IWord
{
    public Word(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public static Word operator -(Word a) => new($"not {a}");
    public static Word operator +(Word a, Word b) => new($"{a} {b}");
    public static Word operator -(Word a, Word b) => a + (-b);
}

public interface IWord
{
    public string Name { get; set; }
    
    public static IWord operator -(IWord a) => a;
}