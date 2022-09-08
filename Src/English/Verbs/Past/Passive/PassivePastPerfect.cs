namespace English.Verbs.Past;

public class PassivePastPerfect : Verb
{
    public PassivePastPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PassivePastPerfect)
    {
    }
    public override string ToStringFor(IPersons subject) => "had been " + PastParticiple;
}