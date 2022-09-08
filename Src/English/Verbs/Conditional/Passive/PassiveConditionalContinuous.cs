using English.Persons;

namespace English.Verbs.Conditional;

public class PassiveConditionalContinuous : Verb
{
    public PassiveConditionalContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveConditionalContinuous)
    {
    }
    public override string ToStringFor(IPersons subject) => "would be being " + PastParticiple;
}