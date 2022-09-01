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

    public override string ToString()
    {
        return $"{Subject} {Verb.ToString(Subject)}";
    }
}