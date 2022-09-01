

using English.Words;

Word i = new (){Name = "I"};
Word am = new (){Name = "am"};
var w3 = i + am;
var w4 = i - am + w3 - (-i);
Console.WriteLine(w3);
Console.WriteLine(w4);