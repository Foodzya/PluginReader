using System;
using System.Collections;
using System.Reflection;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicLoading();
            Console.ReadKey();
        }

        public static void DynamicLoading()
        {
            string pathToDll = @"C:\Users\Smart\source\repos\PluginReader\SomePlugin\bin\Debug\netstandard2.0\SomePlugin.dll";

            try
            {
                Assembly asm = Assembly.LoadFrom(pathToDll);
                Type type = asm.GetType("SomePlugin.Person");

                Type myInterface = type.GetInterface("IInfoReadable");
                if (myInterface != null)
                {
                    object obj = Activator.CreateInstance(type, new object[] { "Alexander", (byte)22, "Belarus" });
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
    }
}