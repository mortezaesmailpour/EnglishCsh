namespace English.Verbs;

internal class CompVerb : Verb
{
    string Qustion = "";

    public CompVerb(string baseForm, string? pastSimple = null, string? pastParticiple = null, Tense? tense = null) 
        : base(baseForm, pastSimple, pastParticiple, tense)
    {
    }
}
