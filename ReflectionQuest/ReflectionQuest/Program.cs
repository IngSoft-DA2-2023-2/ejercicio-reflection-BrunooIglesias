// See https://aka.ms/new-console-template for more information
using ReflectionQuest;
using System.Reflection;
ReflectionHelper reflectionHelper = new ReflectionHelper();
Console.WriteLine("What's your team number?");
bool ok = false;
int number = 0;
while (!ok)
{
    try
    {
        number = Int32.Parse(Console.ReadLine());
        ok = true;
    }
    catch (Exception ex)
    {
        Console.WriteLine("That's not your team number :( ");
    }
}
switch (number)
{
    case 1:
        reflectionHelper.GetNonStaticPublicClassMemberMethodWithLargestArgumentList(@"../../../../ClassLibrary1");
        break;
    case 2:
        reflectionHelper.FindMethodWithLocalVariablesOfTypeIntAndBool(@"../../../../ClassLibrary2");
        break;
    case 3:
        reflectionHelper.GetTypeThatImplementsIEnumerable(@"../../../../ClassLibrary1");
        break;
    case 4:
        break;
        reflectionHelper.GetTypeThatHasNestedTypeInSpanish(@"../../../../ClassLibrary2");
}


