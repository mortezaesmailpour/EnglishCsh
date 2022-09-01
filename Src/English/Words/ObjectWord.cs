namespace English.Words;

public class ObjectWord : Word
{
    public static ObjectWord operator +(ObjectWord a) =>
        (a.Name.EndsWith('s') || a.Name.EndsWith('z') || a.Name.EndsWith('x'))
            ? new ObjectWord($"{a}es")
            : new ObjectWord($"{a}s");

    public ObjectWord(string name) : base(name)
    {
    }
}