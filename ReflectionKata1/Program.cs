using System;

namespace ReflectionKata1
{
    class Program
    {
        static void Main(string[] args)
        {
            InvokeAllMethodsOnReflectionTestsClass();

            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }

        public static void InvokeAllMethodsOnReflectionTestsClass()
        {
            var tests = new ReflectionTests();
            var methods = typeof (ReflectionTests).GetMethods();
            foreach (var method in methods)
            {
                if (method.ReturnType == typeof (void))
                {
                    method.Invoke(tests, new object[] {});
                }
            }
        }
    }
}
