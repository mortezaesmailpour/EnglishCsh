using English.Persons;

namespace English.Verbs.Conditional;

public class PassiveConditionalPerfectContinuous : Verb
{
    public PassiveConditionalPerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveConditionalPerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "would has been being " + PastParticiple,
        _ => "would have been being " + PastParticiple,
    };
}