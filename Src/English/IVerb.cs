namespace English;

public interface IVerb
{
    Tense Tense { get; }
    string ToString(ISubject subject);
}