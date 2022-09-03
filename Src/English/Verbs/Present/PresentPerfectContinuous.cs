using English.PersonGenderNumbers;
using English.SentenceElements;

namespace English.Verbs.Present;

public class PresentPerfectContinuous : Verb
{
    public PresentPerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PresentPerfectContinuous)
    {
    }

    public override string ToStringFor(ISubject subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "has been " + Gerund,
        _ => "have been " + Gerund,
    };
}