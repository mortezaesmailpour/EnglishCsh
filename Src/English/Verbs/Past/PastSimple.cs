namespace English.Verbs.Past;

public class PastSimple : Verb
{
    public PastSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null) : base(baseForm,
        Tense.PastSimple, pastSimple, pastParticiple)
    {
    }

    public override string ToString(ISubject subject) => PastSimple;
}