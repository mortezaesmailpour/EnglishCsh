namespace English.Verbs.Past;

public class PastContinuous : Verb
{
    public PastContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) : base(baseForm,
        Tense.PastContinuous, pastSimple, pastParticiple)
    {
    }

    public override string ToString(ISubject subject) => subject.Number switch
    {
        Number.Singular => "was " + Gerund,
        _ => "were " + Gerund,
    };
}