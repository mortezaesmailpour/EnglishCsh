namespace English;

public abstract class Verb :IVerb
{
    protected Verb(ISubjet subjet, IObject objetct)
    {
        //  Sentence = . . . 
    }

    public ISentence Sentence { get; }
}