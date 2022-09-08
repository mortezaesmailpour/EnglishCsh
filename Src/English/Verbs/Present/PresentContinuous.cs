using English.Persons;

namespace English.Verbs.Present;

public class PresentContinuous : Verb
{
    public PresentContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PresentContinuous)
    {
    }
    public override string ToStringFor(IPersons subject) => subject.Person switch
    {
        Person.First when subject.Number == Number.Singular => "am " + Gerund,
        Person.Third when subject.Number == Number.Singular => "is " + Gerund,
        _ => "are " + Gerund,
    };
}