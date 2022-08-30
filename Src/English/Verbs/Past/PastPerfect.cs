namespace English.Verbs.Past;

public class PastPerfect : Verb
{
    public PastPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null) : base(baseForm,
        Tense.PastPerfect, pastSimple, pastParticiple)
    {
    }

    public override string ToString(ISubject subject) => "had " + PastParticiple;
}