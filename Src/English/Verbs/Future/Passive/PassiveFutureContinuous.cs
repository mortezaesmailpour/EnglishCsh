namespace English.Verbs.Future;

public class PassiveFutureContinuous : Verb
{
    public PassiveFutureContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveFutureContinuous)
    {
    }
    public override string ToStringFor(IPersons subject) => "will be being " + PastParticiple;
}