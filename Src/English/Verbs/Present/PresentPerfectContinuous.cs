namespace English.Verbs.Persent;

public class PresentPerfectContinuous : Verb
{
    public PresentPerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) : base(
        baseForm, Tense.PresentPerfectContinuous, pastSimple, pastParticiple)
    {
    }

    public override string ToString(ISubject subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "has been " + Gerund,
        _ => "have been " + Gerund,
    };
}