using English.PersonGenderNumbers;
using English.Persons;
using English.SentenceElements;

namespace English.Verbs.Present;

public class PresentPerfectContinuous : Verb
{
    public PresentPerfectContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PresentPerfectContinuous)
    {
    }

    public override string ToStringFor(IPersons subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "has been " + Gerund,
        _ => "have been " + Gerund,
    };
}