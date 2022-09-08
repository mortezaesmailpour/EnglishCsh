namespace English.Persons;

public static class Extensions
{
    public static bool Is(this PersonsEnum source, PersonsEnum persons)
        => (source & persons) == persons;
}