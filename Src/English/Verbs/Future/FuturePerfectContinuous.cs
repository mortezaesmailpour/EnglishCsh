using English.Persons;

namespace English.Verbs.Future;

public class FuturePerfectContinuous : Verb
{
    public FuturePerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.FuturePerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons  subject) => "will have been " + Gerund;
}