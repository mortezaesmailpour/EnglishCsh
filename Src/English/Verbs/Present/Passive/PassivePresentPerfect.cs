using English.Persons;

namespace English.Verbs.Present;

public class PassivePresentPerfect : Verb
{
    public PassivePresentPerfect(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PassivePresentPerfect)
    {
    }
    public override string ToStringFor(IPersons  subject) => subject.Person switch
    {
        Person.Third when subject.Number == Number.Singular => "has been " + PastParticiple,
        _ => "have been " + PastParticiple,
    };
}