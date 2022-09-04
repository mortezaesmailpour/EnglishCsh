using English.Verbs;

namespace English.SentenceElements;

public class SubjecVerb : ISentenceElement
{
    public ISubject Subject;
    public IVerb Verb;

    public SubjecVerb(ISubject subject, IVerb verb)
    {
        Subject = subject;
        Verb = verb;
    }

    public static Sentence operator +(SubjecVerb a, IObject b) => new (a.Subject,a.Verb,b);
    public override string ToString()
    {
        return $"{Subject} {Verb.ToStringFor(Subject)}";
    }
}