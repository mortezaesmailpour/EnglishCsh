using English.Persons;

namespace English.Verbs.Future;

public class FuturePerfect : Verb
{
    public FuturePerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.FuturePerfect)
    {
    }

    public override string ToStringFor(IPersons  subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "will has " + PastParticiple,
        _ => "will have " + PastParticiple,
    };
}