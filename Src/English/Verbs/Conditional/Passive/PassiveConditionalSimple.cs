namespace English.Verbs.Conditional;

public class PassiveConditionalSimple : Verb
{
    public PassiveConditionalSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveConditionalSimple)
    {
    }

    public override string ToStringFor(IPersons subject) => "would be " + PastParticiple;
}