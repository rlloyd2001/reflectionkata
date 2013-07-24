using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionKata1
{
    public class ReflectionTests
    {
        private Type type = typeof (ReflectionTarget);

        public void print_the_name_of_reflection_target()
        {
            Console.WriteLine("Reflection Target: " + type.Name);
        }

        public void print_the_full_name_of_reflection_target()
        {
            Console.WriteLine("Reflection Full Name: " + type.Name);
        }

        public void print_the_assembly_qualified_name_of_reflection_target()
        {
            Console.WriteLine("Reflection Assembly Qualified Name: " + type.AssemblyQualifiedName);
        }

        public void print_the_name_of_the_assembly()
        {
            Console.WriteLine("Assembly: " + type.Assembly.GetName());
        }

        public void print_the_name_of_method1()
        {
            var method = type.GetMethod("Method1");
            Console.WriteLine("Method1 Name: " + method.Name);
        }

        public void print_the_parameter_names_of_method1()
        {
            var method = type.GetMethod("Method1");
            foreach (var param in method.GetParameters())
            {
                Console.WriteLine("Param: " + param.Name);
            }
        }

        public void print_the_return_type_of_method1()
        {
            var method = type.GetMethod("Method1");
            Console.WriteLine("Method1 Return Type: " + method.ReturnType.Name);
        }

        public void invoke_method2_twice_printing_the_return_value_each_time()
        {
            var obj = new ReflectionTarget();
            var method = type.GetMethod("Method2");
            for (var i = 0; i < 2; i++)
            {
                var retVal = method.Invoke(obj, new[] {"hello world"});
                Console.WriteLine(retVal);
            }
        }

        public void reset_the_counter_and_print_the_return_value_of_method2()
        {
            var field = type.GetField("Counter", BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(null, 0);
            var obj = new ReflectionTarget();
            var method = type.GetMethod("Method2");
            var retVal = method.Invoke(obj, new []{"hello world"});
            Console.WriteLine(retVal);
        }

        public void print_the_name_and_type_of_each_property()
        {
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                Console.WriteLine(prop.Name + ": " + prop.PropertyType.Name);
            }
        }

        public void set_the_value_of_each_property_then_print_the_to_string_value()
        {
            var obj = new ReflectionTarget();
            var props = type.GetProperties();
            var i = 10;
            foreach (var prop in props)
            {
                i++;
                prop.SetValue(obj, i.ToString());
                Console.WriteLine(prop.GetValue(obj).ToString());
            }
        }
    }
}
