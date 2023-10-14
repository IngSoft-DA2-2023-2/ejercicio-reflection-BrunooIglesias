using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionQuest
{
    internal class ReflectionHelper
    {
        public MemberInfo GetNonStaticPublicClassMemberMethodWithLargestArgumentList(string assemblyPath)
        {
            Console.WriteLine("Get the name of a class member which is non static nad has the largest argument list in assembly");
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Console.ReadLine();
            throw new NotImplementedException("Not implemented D:");
        }

        public MemberInfo FindMethodWithLocalVariablesOfTypeIntAndBool(string assemblyPath)
        {
            Console.WriteLine("Get the name of a method with local variables of type bool and int");
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Console.ReadLine();
            throw new NotImplementedException("Not implemented D:");
        }

        public MemberInfo GetTypeThatImplementsIEnumerable(string assemblyPath)
        {
            Console.WriteLine("Get the name of a type that implements IEnumerable");
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Console.ReadLine();
            throw new NotImplementedException("Not implemented D:");
        }

        public MemberInfo GetTypeThatHasNestedTypeInSpanish(string assemblyPath)
        {
            Console.WriteLine("Get the name of a class member which has a nested type in spanish");
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Console.ReadLine();
            throw new NotImplementedException("Not implemented D:");
        }
    }
}
