namespace English.Verbs.Persent;

public class PresentPerfect : Verb
{
    public PresentPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null) : base(baseForm,
        Tense.PresentPerfect, pastSimple, pastParticiple)
    {
    }

    public override string ToString(ISubject subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "has " + PastParticiple,
        _ => "have " + PastParticiple,
    };
}