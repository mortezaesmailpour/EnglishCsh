namespace English.Words;

public class Word
{
    public string Name;

    public override string ToString()
    {
        return Name;
    }


    public static Word operator +(Word a) => new() { Name = $" {a}" };
    public static Word operator -(Word a) => new() { Name =  $"not {a}"  };

    public static Word operator +(Word a, Word b) => new () { Name = $"{a} {b}" };
    public static Word operator -(Word a, Word b) => a + (-b);
}