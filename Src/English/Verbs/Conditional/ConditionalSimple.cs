namespace English.Verbs.Conditional;

public class ConditionalSimple : Verb
{
    public ConditionalSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.ConditionalSimple)
    {
    }

    public override string ToStringFor(IPersons  subject) => "would " + BaseForm;
}