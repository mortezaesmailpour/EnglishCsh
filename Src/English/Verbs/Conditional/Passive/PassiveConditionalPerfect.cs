using English.Persons;

namespace English.Verbs.Conditional;

public class PassiveConditionalPerfect : Verb
{
    public PassiveConditionalPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveConditionalPerfect)
    {
    }
    public override string ToStringFor(IPersons subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "would has been " + PastParticiple,
        _ => "would have been " + PastParticiple,
    };
}