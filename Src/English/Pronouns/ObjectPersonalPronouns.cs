namespace English.Pronouns;

public class ObjectPersonalPronouns : PersonalPronoun, IObject
{
    public static List<ObjectPersonalPronouns> All => new() { Me, Us, You, Him, Her, It, Them };
    public static ObjectPersonalPronouns Me => new(Person.First, Number.Singular);
    public static ObjectPersonalPronouns Us => new(Person.First);
    public static ObjectPersonalPronouns You => new(Person.Second);
    public static ObjectPersonalPronouns Him => new(Person.Third, Number.Singular, Gender.Male);
    public static ObjectPersonalPronouns Her => new(Person.Third, Number.Singular, Gender.Female);
    public static ObjectPersonalPronouns It => new(Person.Third, Number.Singular);
    public static ObjectPersonalPronouns Them => new(Person.Third);

    public ObjectPersonalPronouns(Person person, Number number = Number.Plural, Gender gender = Gender.Neuter)
        : base(person, number, gender)
    {
    }

    public override string ToString() => Person switch
    {
        Person.First when Number == Number.Singular => "me",
        Person.First when Number == Number.Plural => "us",
        Person.Second => "you",
        Person.Third when Number == Number.Singular && Gender == Gender.Male => "him",
        Person.Third when Number == Number.Singular && Gender == Gender.Female => "her",
        Person.Third when Number == Number.Singular && Gender == Gender.Neuter => "It",
        Person.Third when Number == Number.Plural => "Them",
        _ => throw new ArgumentOutOfRangeException()
    };
}