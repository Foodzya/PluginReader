using System;
using System.Collections;
using System.Reflection;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MyReflectionTest.DynamicLoading();
            Console.ReadKey();
        }
    }

    [Path(@"C:\Users\Smart\source\repos\PluginReader\SomePlugin\bin\Debug\netstandard2.0\SomePlugin.dll")]
    public static class MyReflectionTest
    {
        public static void DynamicLoading()
        {
            string pathToDll = GetPathToLibrary(typeof(MyReflectionTest));
            try
            {
                Assembly asm = Assembly.LoadFrom(pathToDll);
                Type type = asm.GetType("SomePlugin.Person");

                Type myInterface = type.GetInterface("IInfoReadable");
                if (myInterface != null)
                {
                    object obj = Activator.CreateInstance(type, "Alexander", (byte)22, "Belarus");
                    MethodInfo method = type.GetMethod("GetBiography");
                    object result = method.Invoke(obj, null);

                    Console.WriteLine(result);
                }
                else
                    Console.WriteLine("Interface doesn't exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string GetPathToLibrary(Type t)
        {
            PathAttribute pathAttribute = (PathAttribute)Attribute.GetCustomAttribute(t, typeof(PathAttribute));
            if (pathAttribute == null)
            {
                Console.WriteLine("The attribute wasn't found!");
            }
            else
            {
                return pathAttribute.GetPath();
            }
            return "Something goes wrong";
        }
    }
}