using English.PersonGenderNumbers;
using English.Verbs;

namespace English.SentenceElements;

public interface ISubject : IPersonsGender
{
    public static SubjecVerb operator +(ISubject a, IVerb b) => new (a,b);
}