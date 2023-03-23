namespace English.Verbs.Present;

public class PassivePresentPerfectContinuous : Verb
{
    public PassivePresentPerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassivePresentPerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons  subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "has been being " + PastParticiple,
        _ => "have been being " + PastParticiple,
    };
}