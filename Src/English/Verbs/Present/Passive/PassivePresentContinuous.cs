using English.PersonGenderNumbers;
using English.SentenceElements;

namespace English.Verbs.Present;

public class PassivePresentContinuous : Verb
{
    public PassivePresentContinuous(string baseForm, string? pastSimple = null, string? pastParticiple = null) 
        : base(baseForm, pastSimple, pastParticiple, Tense.PassivePresentContinuous)
    {
    }
    public override string ToStringFor(ISubject subject) => subject.Person switch
    {
        Person.First when subject.Number == Number.Singular => "am being " + Gerund,
        Person.Third when subject.Number == Number.Singular => "is being " + Gerund,
        _ => "are being " + Gerund,
    };
}