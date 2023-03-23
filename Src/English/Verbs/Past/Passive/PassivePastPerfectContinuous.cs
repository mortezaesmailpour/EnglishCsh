namespace English.Verbs.Past;

public class PassivePastPerfectContinuous : Verb
{
    public PassivePastPerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassivePastPerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons subject) => "had been being " + PastParticiple;
}