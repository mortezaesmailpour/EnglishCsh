namespace English.Verbs.Future;

public class PassiveFuturePerfectContinuous : Verb
{
    public PassiveFuturePerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveFuturePerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "will has been being " + PastParticiple,
        _ => "will have been being " + PastParticiple,
    };
}