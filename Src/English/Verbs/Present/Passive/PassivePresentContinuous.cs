namespace English.Verbs.Present;

public class PassivePresentContinuous : Verb
{
    public PassivePresentContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassivePresentContinuous)
    {
    }
    public override string ToStringFor(IPersons  subject) => subject.Person switch
    {
        Person.First when subject.Number == Number.Singular => "am being " + PastParticiple,
        Person.Third when subject.Number == Number.Singular => "is being " + PastParticiple,
        _ => "are being " + PastParticiple,
    };
}