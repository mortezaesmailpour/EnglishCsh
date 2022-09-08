using English.PersonGenderNumbers;
using English.Persons;
using English.SentenceElements;

namespace English.Verbs.Conditional;

public class ConditionalContinuous : Verb
{
    public ConditionalContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.ConditionalContinuous)
    {
    }

    public override string ToStringFor(IPersons  subject) => "would be " + Gerund;
}