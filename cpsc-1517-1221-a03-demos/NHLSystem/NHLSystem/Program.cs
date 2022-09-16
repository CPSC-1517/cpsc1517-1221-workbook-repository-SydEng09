// See https://aka.ms/new-console-template for more information
using NHLSystem;

//var validPerson = new Person("Connor McDavid");
//Console.WriteLine(validPerson.FullName);

try
{
    var nullPerson = new Person(null);
    Console.WriteLine("Null test case failed");
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.ParamName);
}

try
{
    var emptyPerson = new Person("");
    Console.WriteLine("Blank test case failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.ParamName);
}

try
{
    var whitespacePerson = new Person("     ");
    Console.WriteLine("Whitespace test case failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    var invalidlenghtPerson = new Person("AB");
    Console.WriteLine("Min lenght test case failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}