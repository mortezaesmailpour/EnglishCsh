namespace English;

public class PersonalPronouns : ISubject
{
    public Gender Gender { get; set; }
    public Person Person { get; set; }
    public Number Number { get; set; }
    public static PersonalPronouns I => new (Person.First, Number.Singular);
    public static PersonalPronouns We => new (Person.First);
    public static PersonalPronouns You => new (Person.Second);
    public static PersonalPronouns He => new (Person.Third, Number.Singular, Gender.Male);
    public static PersonalPronouns She => new (Person.Third, Number.Singular, Gender.Female);
    public static PersonalPronouns It => new (Person.Third, Number.Singular);
    public static PersonalPronouns They => new (Person.Third);

    public PersonalPronouns(Person gerson, Number number = Number.Plural, Gender gender = Gender.Neuter)
    {
        Gender = gender;
        Person = gerson;
        Number = number;
    }

    public override string ToString() => Person switch
    {
        Person.First when Number == Number.Singular => "I",
        Person.First when Number == Number.Plural => "We",
        Person.Second => "you",
        Person.Third when Number == Number.Singular && Gender == Gender.Male => "He",
        Person.Third when Number == Number.Singular && Gender == Gender.Female => "She",
        Person.Third when Number == Number.Singular && Gender == Gender.Neuter => "It",
        Person.Third when Number == Number.Plural => "They",
        _ => throw new ArgumentOutOfRangeException()
    };
}