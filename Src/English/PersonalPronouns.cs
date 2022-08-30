namespace English;

public class PersonalPronouns : ISubjet
{
    public Gender Gender { get; set; }
    public Person Person { get; set; }
    public Number Number { get; set; }

    public PersonalPronouns(Gender gender, Person gerson, Number number )
    {
        Gender = gender;
        Person = gerson;
        Number = number;
    }
    public string ToStringA() 
    {
        return Person switch 
        {
            Person.First when Number == Number.Singular => "I",
            Person.First when Number == Number.Plural => "We",
            Person.Second => "you",
            Person.Third when Number  == Number.Singular &&  Gender == Gender.Male => "He",
            Person.Third when Number  == Number.Singular &&  Gender == Gender.Female => "She",
            Person.Third when Number  == Number.Singular &&  Gender == Gender.Neuter => "It",
            Person.Third when Number  == Number.Plural => "They",
            _ =>  throw new ArgumentOutOfRangeException()
        };
    }
    public string ToStringB()
    {
        if (Person == Person.First & Number == Number.Singular)
            return "I";
        if (Person == Person.First & Number == Number.Plural)
            return "We";
        if (Person == Person.Second)
            return "you";
        if (Person == Person.Third & Number == Number.Singular)
        {
            if (Gender == Gender.Male)
                return "He";
            if (Gender == Gender.Female)
                return "She";
            if (Gender == Gender.Neuter)
                return "It";
        }
        if (Person == Person.Third & Number == Number.Plural)
            return "They";
        throw new ArgumentOutOfRangeException();
    }
}