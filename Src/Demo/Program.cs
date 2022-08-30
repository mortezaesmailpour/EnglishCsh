
using BenchmarkDotNet.Running;
using Demo;
using English;
using English.Verbs.Persent;

//BenchmarkRunner.Run<Benchmarks>();

var play = new PresentSimple("play");
var he = new PersonalPronouns(Gender.Male, Person.Third, Number.Singular);

Console.WriteLine(play.ToString(he));

var playing = play.Perfect();
Console.WriteLine(playing.ToString(he));
var played = playing.Past().Continuous();
Console.WriteLine(played.ToString(he));