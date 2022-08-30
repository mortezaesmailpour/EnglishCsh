namespace English;

public class Sentence : ISentence
{
    public ISubject Subject { get; set; }
    public IVerb Verb { get; set; }
    public IObject? Object { get; set; }

    public Sentence(ISubject subject, IVerb verb, IObject? @object)
    {
        Subject = subject;
        Verb = verb;
        Object = @object;
    }

    public override string ToString()
    {
        return Verb.ToString(Subject) + Object;
    }
}