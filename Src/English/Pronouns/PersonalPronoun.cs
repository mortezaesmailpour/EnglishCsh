using English.PersonGenderNumbers;

namespace English.Pronouns;

public abstract class PersonalPronoun : IPersonGenderNumber
{
    public Gender Gender { get; set; }
    public Person Person { get; set; }
    public Number Number { get; set; }
    
    protected PersonalPronoun(Person gerson, Number number = Number.Plural, Gender gender = Gender.Neuter)
    {
        Gender = gender;
        Person = gerson;
        Number = number;
        if (Person == Person.Second  && Number == Number.Singular)
            Number = Number.Plural;
    }

    public abstract override string ToString();
}