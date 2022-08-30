using BenchmarkDotNet.Attributes;
using English;

namespace Demo;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    List<PersonalPronouns> list =new ()
    {
        new PersonalPronouns(Gender.Male, Person.First, Number.Singular),
        new PersonalPronouns(Gender.Female, Person.First, Number.Singular),
        new PersonalPronouns(Gender.Neuter, Person.First, Number.Singular),
        new PersonalPronouns(Gender.Male, Person.Second, Number.Singular),
        new PersonalPronouns(Gender.Female, Person.Second, Number.Singular),
        new PersonalPronouns(Gender.Neuter, Person.Second, Number.Singular),
        new PersonalPronouns(Gender.Male, Person.Third, Number.Singular),
        new PersonalPronouns(Gender.Female, Person.Third, Number.Singular),
        new PersonalPronouns(Gender.Neuter, Person.Third, Number.Singular),
        new PersonalPronouns(Gender.Male, Person.First, Number.Plural),
        new PersonalPronouns(Gender.Female, Person.First, Number.Plural),
        new PersonalPronouns(Gender.Neuter, Person.First, Number.Plural),
        new PersonalPronouns(Gender.Male, Person.Second, Number.Plural),
        new PersonalPronouns(Gender.Female, Person.Second, Number.Plural),
        new PersonalPronouns(Gender.Neuter, Person.Second, Number.Plural),
        new PersonalPronouns(Gender.Male, Person.Third, Number.Plural),
        new PersonalPronouns(Gender.Female, Person.Third, Number.Plural),
        new PersonalPronouns(Gender.Neuter, Person.Third, Number.Plural),
    } ;
    [Benchmark]
    public void ToStringA()
    {
        foreach (var pronoun in list)
        {
            pronoun.ToStringA();
        }
    }
    [Benchmark]
    public void ToStringB()
    {
        foreach (var pronoun in list)
        {
            pronoun.ToStringB();
        }
    }
}
