using English.PersonGenderNumbers;
using English.SentenceElements;

namespace English.Words;

public class SubjectWord : Word, ISubject
{
    private readonly ISubject _subject;

    public SubjectWord(ISubject subject) : base(subject.ToString())
    {
        _subject = subject;
    }

    public Number Number
    {
        get => _subject.Number;
        set => _subject.Number = value;
    }

    public Gender Gender
    {
        get => _subject.Gender;
        set => _subject.Gender = value;
    }

    public Person Person
    {
        get => _subject.Person;
        set => _subject.Person = value;
    }
}