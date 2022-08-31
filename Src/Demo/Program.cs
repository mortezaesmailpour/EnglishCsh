
using BenchmarkDotNet.Running;
using Demo;
using English;
using English.Verbs;
using English.Verbs.Present;

//BenchmarkRunner.Run<Benchmarks>();

var play = new PresentSimple("play");
var go = new PresentSimple("go","went","gone");
var he = new PersonalPronouns( Person.First, Number.Singular);

Console.WriteLine(go.ToString(he));

var playing = play.Continuous();
Console.WriteLine(playing.ToString(he));
var played = playing.Past().Continuous();
Console.WriteLine(played.ToString(he));

var seen = Irregulars.See.Past().Perfect();

Console.WriteLine(seen.ToString(he));

