namespace English.Verbs.Persent;

public class PresentContinuous : Verb
{
    public PresentContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) : base(baseForm,
        Tense.PresentContinuous, pastSimple, pastParticiple)
    {
    }

    public override string ToString(ISubject subject) => subject.Person switch
    {
        Person.First when subject.Number == Number.Singular => "am " + Gerund,
        Person.Third when subject.Number == Number.Singular => "is " + Gerund,
        _ => "are " + Gerund,
    };
}