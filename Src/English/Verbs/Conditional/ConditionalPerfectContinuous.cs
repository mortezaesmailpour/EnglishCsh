namespace English.Verbs.Conditional;

public class ConditionalPerfectContinuous : Verb
{
    public ConditionalPerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.ConditionalPerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "would has been " + Gerund,
        _ => "would have been " + Gerund,
    };
}