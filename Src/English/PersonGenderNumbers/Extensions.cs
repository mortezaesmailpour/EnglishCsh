namespace English.PersonGenderNumbers;

public static class Extensions
{
    public static bool Is(this PersonGenderNumber source, PersonGenderNumber personGenderNumber)
        => (source & personGenderNumber) == personGenderNumber;
}