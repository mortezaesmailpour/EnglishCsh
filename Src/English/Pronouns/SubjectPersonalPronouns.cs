using English.PersonGenderNumbers;

namespace English.Pronouns;

public class SubjectPersonalPronouns : PersonalPronoun, ISubject
{
    public static SubjectPersonalPronouns I => new(Person.First, Number.Singular);
    public static SubjectPersonalPronouns We => new(Person.First);
    public static SubjectPersonalPronouns You => new(Person.Second);
    public static SubjectPersonalPronouns He => new(Person.Third, Number.Singular, Gender.Male);
    public static SubjectPersonalPronouns She => new(Person.Third, Number.Singular, Gender.Female);
    public static SubjectPersonalPronouns It => new(Person.Third, Number.Singular);
    public static SubjectPersonalPronouns They => new(Person.Third);

    public SubjectPersonalPronouns(Person person, Number number = Number.Plural, Gender gender = Gender.Neuter)
        : base(person, number, gender)
    {
    }
    public SubjectPersonalPronouns(PersonGenderNumber p)
        : base(p.Is(PersonGenderNumber.First)?Person.First:p.Is(PersonGenderNumber.Second)?Person.Second: Person.Third,
            p.Is(PersonGenderNumber.Plural)?Number.Plural:Number.Singular, 
            p.Is(PersonGenderNumber.Male)? Gender.Male: p.Is(PersonGenderNumber.Female)?Gender.Female: Gender.Neuter)
    {
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