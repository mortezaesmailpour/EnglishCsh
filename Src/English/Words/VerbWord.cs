using English.PersonGenderNumbers;
using English.Pronouns;
using English.SentenceElements;
using English.Verbs;
using IVerb = English.Verbs.IVerb;

namespace English.Words;

public class VerbWord : Word
{
    public VerbWord(IVerb verb) : base(verb.ToString(new SubjectPersonalPronouns(Person.First)))
    {
        Verb = verb;
    }

    public static Word operator +(SubjectWord a, VerbWord b) => new($"{a} {b.ToString(a)}");
    public IVerb Verb { get; set; }
    public string ToString(ISubject subject)
    {
        return Verb.ToString(subject);
    }
}