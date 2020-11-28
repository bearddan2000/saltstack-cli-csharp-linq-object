using System;
using System.Linq;
using System.Collections.Generic;

namespace MyAppCshrp
{
    class Person
    {
        public String Name { get; set; }
        public int Age { get; set; }

        public override String ToString()
        {
            return String.Format("Name: {0}, Age: {1}", Name, Age.ToString("D2"));
        }
    }
    class MainClass
    {
        private static void print(IEnumerable<Person> result, String query)
        {
            Console.WriteLine("[QUERY] {0}", query);
            foreach (Person i in result)
                Console.WriteLine("[OUTPUT] {0}", i);
        }
        private static void greaterThan(List<Person> list)
        {
            var result = (from x in list where x.Age > 1 select x);
            print(result, "SELECT * FROM list WHERE age > 1;");
        }
        private static void lessThan(List<Person> list)
        {
            var result = (from x in list where x.Age < 2 select x);
            print(result, "SELECT * FROM list WHERE age < 2;");
        }
        private static void equals(List<Person> list)
        {
            var result = (from x in list where x.Age == 1 select x);
            print(result, "SELECT * FROM list WHERE age = 1;");
        }
        public static void Main(string[] args)
        {
            List<Person> list = new List<Person>() {
                        new Person(){Name="Adam", Age=0},
                        new Person(){Name="Betty", Age=1},
                        new Person(){Name="Charlie", Age=2}
            };
            Console.WriteLine("[INPUT] {0}", String.Join<Person>(", ", list.ToArray()));
            greaterThan(list);
            lessThan(list);
            equals(list);
        }
    }
}
