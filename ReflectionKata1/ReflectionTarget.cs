using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionKata1
{
    public class ReflectionTarget
    {
        private static int Counter = 0;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Method1(string a, string b, string c)
        {
        }

        public string Method2(string input)
        {
            Counter++;
            return string.Format("{0} ({1})", input, Counter);
        }

        private static void reset()
        {
            Counter = 0;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}; Email: {2}", FirstName, LastName, Email);
        }
    }
}
