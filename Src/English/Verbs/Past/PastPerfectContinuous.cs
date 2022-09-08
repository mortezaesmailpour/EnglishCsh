using English.Persons;

namespace English.Verbs.Past;

public class PastPerfectContinuous : Verb
{
    public PastPerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PastPerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons  subject) => "had been " + Gerund;
}