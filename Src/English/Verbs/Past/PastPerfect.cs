using English.SentenceElements;

namespace English.Verbs.Past;

public class PastPerfect : Verb
{
    public PastPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PastPerfect)
    {
    }

    public override string ToStringFor(ISubject subject) => "had " + PastParticiple;
}