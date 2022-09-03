using English.PersonGenderNumbers;
using English.SentenceElements;

namespace English.Verbs.Conditional;

public class ConditionalPerfect : Verb
{
    public ConditionalPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.ConditionalPerfect)
    {
    }

    public override string ToStringFor(ISubject subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "would has " + PastParticiple,
        _ => "would have " + PastParticiple,
    };
}