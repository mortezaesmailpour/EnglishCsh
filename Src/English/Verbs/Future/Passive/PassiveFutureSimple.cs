using English.Persons;

namespace English.Verbs.Future;

public class PassiveFutureSimple : Verb
{
    public PassiveFutureSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.PassiveFutureSimple)
    {
    }

    public override string ToStringFor(IPersons subject) => "will be " + PastParticiple;
}