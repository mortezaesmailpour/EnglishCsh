namespace English.Verbs.Conditional;

public class ConditionalPerfect : Verb
{
    public ConditionalPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.ConditionalPerfect)
    {
    }

    public override string ToStringFor(IPersons  subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "would has " + PastParticiple,
        _ => "would have " + PastParticiple,
    };
}