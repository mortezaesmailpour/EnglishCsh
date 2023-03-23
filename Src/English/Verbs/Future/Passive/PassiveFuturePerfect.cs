namespace English.Verbs.Future;

public class PassiveFuturePerfect : Verb
{
    public PassiveFuturePerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveFuturePerfect)
    {
    }

    public override string ToStringFor(IPersons subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "will has been " + PastParticiple,
        _ => "will have been " + PastParticiple,
    };
}