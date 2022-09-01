using English.SentenceElements;

namespace English.Verbs.Past;

public class PastSimple : Verb
{
    public PastSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PastSimple)
    {
    }

    public override string ToString(ISubject subject) => PastSimple;
}