using English.Persons;

namespace English.Verbs.Past;

public class PassivePastContinuous : Verb
{
    public PassivePastContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassivePastContinuous)
    {
    }

    public override string ToStringFor(IPersons subject) => subject.Number switch
    {
        Number.Singular => "was being " + PastParticiple,
        _ => "were being " + PastParticiple,
    };
}