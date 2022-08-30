// See https://aka.ms/new-console-template for more information

using English;

Console.WriteLine("Hello, World!");


var pr = new PersonalPronouns(Gender.Female, Person.Third, Number.Plural);

Console.WriteLine(pr.ToStringA());
Console.WriteLine(pr.ToStringB());
