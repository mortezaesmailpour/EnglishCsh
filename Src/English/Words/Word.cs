namespace English.Words;

public class Word
{
    public string Name;

    public override string ToString()
    {
        return Name;
    }

    public static Word Plus(Word a, Word b)
    {
        return new Word() { Name = a.Name + " + " + b /*.Name*/ };
    }


    public static Word operator +(Word a) => new() { Name = " + " + a };
    public static Word operator -(Word a) => new() { Name = " - " + a };

    public static Word operator +(Word a, Word b) => Plus(a, b);
    public static Word operator -(Word a, Word b) => a + (-b);
}