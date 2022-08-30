namespace English.Verbs.Persent;

public class PresentSimple : Verb
{
    public PresentSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null) : base(baseForm,
        Tense.PresentSimple, pastSimple, pastParticiple)
    {
    }

    public override string ToString(ISubject subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => BaseForm + "s",
        _ => BaseForm
    };
}