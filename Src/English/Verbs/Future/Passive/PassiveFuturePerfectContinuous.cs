namespace English.Verbs.Future;

public class PassiveFuturePerfectContinuous : Verb
{
    public PassiveFuturePerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveFuturePerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons subject) => "will have been being " + PastParticiple;
}