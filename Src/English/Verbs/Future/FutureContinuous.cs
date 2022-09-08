using English.Persons;

namespace English.Verbs.Future;

public class FutureContinuous : Verb
{
    public FutureContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.FutureContinuous)
    {
    }

    public override string ToStringFor(IPersons  subject) => "will be " + Gerund;
}