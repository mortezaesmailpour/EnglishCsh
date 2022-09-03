using English.PersonGenderNumbers;
using English.SentenceElements;

namespace English.Verbs.Past;

public class PastContinuous : Verb
{
    public PastContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PastContinuous)
    {
    }

    public override string ToStringFor(ISubject subject) => subject.Number switch
    {
        Number.Singular => "was " + Gerund,
        _ => "were " + Gerund,
    };
}