using English.Persons;

namespace English.Verbs;

public interface IVerb
{
    Tense Tense { get; }
    public Verb Present();
    public Verb Past();
    public Verb Future();
    public Verb Conditional();

    public Verb Simple();
    public Verb Continuous();
    public Verb Perfect();
    
    string ToStringFor(IPersons subject);
}