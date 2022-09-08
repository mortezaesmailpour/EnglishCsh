namespace English.Persons;

public class Persons : IPersons
{

    public PersonsEnum PersonsEnum { get; set; }
    public Person Person
    {
        get => PersonsEnum.Is(PersonsEnum.First) ? Person.First : PersonsEnum.Is(PersonsEnum.Second) ? Person.Second : Person.Third;
        set => _=value;
    }
    public Number Number
    {
        get => PersonsEnum.Is(PersonsEnum.Singular) ? Number.Singular : Number.Plural;
        set => _ = value;
    }
}
