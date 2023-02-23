namespace English.Verbs;

public interface IVerb
{
    Tense Tense { get; }
    public IVerb ChangeTense(Tense tense);
    public IVerb Present();
    public IVerb Past();
    public IVerb Future();
    public IVerb Conditional();

    public IVerb Simple();
    public IVerb Continuous();
    public IVerb Perfect();
    
    string ToStringFor(IPersons subject);
}