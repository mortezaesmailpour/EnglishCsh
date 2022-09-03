using English.PersonGenderNumbers;
using English.SentenceElements;

namespace English.Verbs.Present;

public class PresentPerfect : Verb
{
    public PresentPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PresentPerfect)
    {
    }
    public override string ToStringFor(ISubject subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "has " + PastParticiple,
        _ => "have " + PastParticiple,
    };
}