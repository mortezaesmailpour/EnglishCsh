using English.Persons;

namespace English.Verbs.Past;

public class PassivePastSimple : Verb
{
    public PassivePastSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PassivePastSimple)
    {
    }

    public override string ToStringFor(IPersons subject) => subject.Number switch
    {
        Number.Singular => "was " + PastParticiple,
        _ => "were " + PastParticiple,
    };
}