namespace English.Verbs.Present;

public class PresentSimple : Verb
{
    public PresentSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PresentSimple)
    {
    }

    public override string ToStringFor(IPersons  subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => BaseForm + "s",
        _ => BaseForm
    };
}