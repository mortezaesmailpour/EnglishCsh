using English.Verbs;

namespace English;

public static class Extensions
{
    public static bool Is(this Tense source, Tense persons)
        => (source & persons) == persons;
}