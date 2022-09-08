using English.Persons;

namespace English.Verbs.Past;

public class PastSimple : Verb
{
    public PastSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PastSimple)
    {
    }

    public override string ToStringFor(IPersons  subject) => PastSimple;
}