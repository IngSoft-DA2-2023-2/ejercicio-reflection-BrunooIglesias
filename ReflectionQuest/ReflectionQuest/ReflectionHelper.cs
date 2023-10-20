using System.Reflection;

namespace ReflectionQuest
{
    internal class ReflectionHelper
    {
        public MemberInfo GetNonStaticPublicClassMemberMethodWithLargestArgumentList(string assemblyPath)
        {
            Console.WriteLine("Getting the name of a class member which is non-static and has the largest argument list in the assembly.");
            Assembly assembly = Assembly.LoadFrom(assemblyPath);

            MemberInfo result = null;
            int maxParameterCount = 0;

            foreach (Type type in assembly.GetTypes())
            {
                foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (!methodInfo.IsStatic)
                    {
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        int parameterCount = parameters.Length;

                        if (parameterCount > maxParameterCount)
                        {
                            maxParameterCount = parameterCount;
                            result = methodInfo;
                        }
                    }
                }
            }

            if (result != null)
            {
                Console.WriteLine($"Method '{result.Name}' in class '{result.DeclaringType?.Name}' has the largest argument list with {maxParameterCount} parameters.");
            }
            else
            {
                Console.WriteLine("No non-static public class member method found in the assembly.");
            }

            return result;
        }

        public MemberInfo FindMethodWithLocalVariablesOfTypeIntAndBool(string assemblyPath)
        {
            Console.WriteLine("Getting the name of a method with local variables of type bool and int in the assembly.");
            Assembly assembly = Assembly.LoadFrom(assemblyPath);

            foreach (Type type in assembly.GetTypes())
            {
                foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    LocalVariableInfo[] localVariables = GetLocalVariables(methodInfo);

                    bool hasInt = false;
                    bool hasBool = false;

                    foreach (var localVar in localVariables)
                    {
                        if (localVar.LocalType == typeof(int))
                        {
                            hasInt = true;
                        }
                        else if (localVar.LocalType == typeof(bool))
                        {
                            hasBool = true;
                        }

                        if (hasInt && hasBool)
                        {
                            Console.WriteLine($"Method '{methodInfo.Name}' in class '{methodInfo.DeclaringType?.Name}' has local variables of type int and bool.");
                            return methodInfo;
                        }
                    }
                }
            }

            Console.WriteLine("No method with local variables of type int and bool found in the assembly.");
            return null;
        }

        private LocalVariableInfo[] GetLocalVariables(MethodBase method)
        {
            var body = method.GetMethodBody();
            if (body != null)
            {
                var localVariables = body.LocalVariables;
                return localVariables.ToArray();
            }
            return new LocalVariableInfo[0];
        }

        public MemberInfo GetTypeThatImplementsIEnumerable(string assemblyPath)
        {
            Console.WriteLine("Getting the name of a type that implements IEnumerable in the assembly.");
            Assembly assembly = Assembly.LoadFrom(assemblyPath);

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
                {
                    Console.WriteLine($"Type '{type.Name}' implements IEnumerable interface.");
                    return type;
                }
            }

            Console.WriteLine("No type implementing IEnumerable interface found in the assembly.");
            return null;
        }

        public MemberInfo GetTypeThatHasNestedTypeInSpanish(string assemblyPath)
        {
            Console.WriteLine("Getting the name of a class member which has a nested type in Spanish in the assembly.");
            Assembly assembly = Assembly.LoadFrom(assemblyPath);

            foreach (Type type in assembly.GetTypes())
            {
                Type[] nestedTypes = type.GetNestedTypes();

                foreach (Type nestedType in nestedTypes)
                {
                    string nestedTypeName = nestedType.Name.ToLower();

                    if (ContainsSpanishCharacters(nestedTypeName))
                    {
                        Console.WriteLine($"Class '{type.Name}' has a nested type '{nestedType.Name}' with Spanish characters.");
                        return nestedType;
                    }
                }
            }

            Console.WriteLine("No class member with a nested type in Spanish found in the assembly.");
            return null;
        }

        private bool ContainsSpanishCharacters(string input)
        {
            string spanishCharacters = "áéíóúñ";

            foreach (char c in input)
            {
                if (spanishCharacters.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
