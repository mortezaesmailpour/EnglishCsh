namespace English;

public interface ISentence
{
    ISubject Subject { get; set; }
    IVerb Verb { get; set; }
    IObject? Object { get; set; }
    
}