using English.SentenceElements;
using English.Verbs;
using IVerb = English.Verbs.IVerb;

namespace English;

public class Sentence : ISentence
{
    public ISubject Subject { get; set; }
    public IVerb Verb { get; set; }
    public IObject? Object { get; set; }
    public static Sentence operator + (Sentence a, IObject b) => new (a.Subject,a.Verb,b);

    public Sentence(ISubject subject, IVerb verb, IObject? @object)
    {
        Subject = subject;
        Verb = verb;
        Object = @object;
    }

    public override string ToString()
    {
        return $"{Subject} {Verb.ToStringFor(Subject)} {Object}";
    }
}