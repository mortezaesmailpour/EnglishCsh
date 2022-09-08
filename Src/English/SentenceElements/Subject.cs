using English.PersonGenderNumbers;
using English.Persons;

namespace English.SentenceElements;

public class Subject : ISubject
{
    public Number Number { get; set ; }
    public Gender Gender { get; set; }
    public Person Person { get; set; }
    public Subject(Person person = Person.First, Number number = Number.Plural, Gender gender = Gender.Neuter)
    {
        Gender = gender;
        Person = person;
        Number = number;
        if (Person == Person.Second && Number == Number.Singular)
            Number = Number.Plural;
        _name = ToString();
    }
    public Subject(string name, Number number = Number.Plural, Gender gender = Gender.Neuter)
    {
        Number = number;
        Gender = gender;
        Person = Person.Third;
        _name = name;
    }
    private string _name { get; set; }
    public override string ToString() => _name;
}
