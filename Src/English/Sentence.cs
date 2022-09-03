using English.SentenceElements;
using English.Verbs;
using IVerb = English.Verbs.IVerb;

namespace English;

public class Sentence : ISentence
{
    public ISubject Subject { get; set; }
    public IVerb Verb { get; set; }
    public IObject? Object { get; set; }
    public IObject? Object2 { get; set; }

    public static Sentence operator +(Sentence a, IObject b) =>
        (a.Object is null) ? new(a.Subject, a.Verb, b) : new(a.Subject, a.Verb, a.Object, b);

    public Sentence(ISubject subject, IVerb verb, IObject? @object = null, IObject? object2 = null)
    {
        Subject = subject;
        Verb = verb;
        Object = @object;
        Object2 = object2;
    }

    public override string ToString()
    {
        return $"{Subject} {Verb.ToStringFor(Subject)} {Object} {Object2}";
    }
}